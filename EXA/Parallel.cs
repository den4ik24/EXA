//Библиотека потоков данных TPL состоит из блоков потоков данных, которые
//представляют собой структуры данных, буферизующие и обрабатывающие данные.

using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EXA
{
    public static class ParallelExample
    {
        public static void ParallelExample1()
        {
            long totalSize = 0;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 1)
            {
                Console.WriteLine("There are no command line arguments.");
                return;
            }
            if (!Directory.Exists(args[1]))
            {
                Console.WriteLine("The directory does not exist.");
                return;
            }

            string[] files = Directory.GetFiles(args[1]);
            Parallel.For(0, files.Length,
                         index =>
                         {
                             FileInfo fi = new FileInfo(files[index]);
                             long size = fi.Length;
                             Interlocked.Add(ref totalSize, size);
                         });
            Console.WriteLine("Directory '{0}':", args[1]);
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
        }

        public static void ParallelExample2()
        {
            Thread.CurrentThread.Name = "Main";
            Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA."));
            Console.WriteLine($"Hello from thread '{Thread.CurrentThread.Name}'.");
            taskA.Wait();
        }

        public static void ParallelExample3()
        {
            var displayData = Task.Factory.StartNew(() =>
            {
                Random rnd = new Random();
                int[] values = new int[100];
                for (int ctr = 0; ctr <= values.GetUpperBound(0); ctr++)
                    values[ctr] = rnd.Next();

                return values;
            }).
                              ContinueWith((x) =>
                              {
                                  int n = x.Result.Length;
                                  long sum = 0;
                                  double mean;

                                  for (int ctr = 0; ctr <= x.Result.GetUpperBound(0); ctr++)
                                      sum += x.Result[ctr];

                                  mean = sum / (double)n;
                                  return Tuple.Create(n, sum, mean);
                              }).
                              ContinueWith((x) =>
                              {
                                  return String.Format("N={0:N0}, Total = {1:N0}, Mean = {2:N2}",
                                                     x.Result.Item1, x.Result.Item2,
                                                     x.Result.Item3);
                              });
            Console.WriteLine(displayData.Result);
        }

        public static void ParallelExample4()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent task beginning.");
                for (int ctr = 0; ctr < 10; ctr++)
                {
                    int taskNo = ctr;
                    Task.Factory.StartNew((x) =>
                    {
                        Thread.SpinWait(5000000);
                        Console.WriteLine("Attached child #{0} completed.",
                                          x);
                    },
                                          taskNo, TaskCreationOptions.AttachedToParent);
                }
            });

            parent.Wait();
            Console.WriteLine("Parent task completed.");
        }

        public static void ParallelExample5()
        {
            List<Task<int>> tasks = new List<Task<int>>();
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                int baseValue = ctr;
                tasks.Add(Task.Factory.StartNew((b) =>
                {
                    int i = (int)b;
                    return i * i;
                }, baseValue));
            }
            var continuation = Task.WhenAll(tasks);

            long sum = 0;
            for (int ctr = 0; ctr <= continuation.Result.Length - 1; ctr++)
            {
                Console.Write("{0} {1} ", continuation.Result[ctr],
                              ctr == continuation.Result.Length - 1 ? "=" : "+");
                sum += continuation.Result[ctr];
            }
            Console.WriteLine(sum);
        }

        public static void ParallelExample6()
        {
            var t = Task.Run(() =>
            {
                DateTime dat = DateTime.Now;
                if (dat == DateTime.MinValue)
                    throw new ArgumentException("The clock is not working.");

                if (dat.Hour > 17)
                    return "evening";
                if (dat.Hour > 12)
                    return "afternoon";
                return "morning";
            });
            var c = t.ContinueWith((antecedent) =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("Good {0}!",
                                      antecedent.Result);
                    Console.WriteLine("And how are you this fine {0}?",
                                   antecedent.Result);
                }
                else if (t.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine(t.Exception.GetBaseException().Message);
                }
            });
        }

        public static void ParallelExample7()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task executing.");

                var child = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Nested task starting.");
                    Thread.SpinWait(500000);
                    Console.WriteLine("Nested task completing.");
                });
            });

            parent.Wait();
            Console.WriteLine("Outer has completed.");
        }

        public static void ParallelExample8()
        {
            var outer = Task<int>.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task executing.");

                var nested = Task<int>.Factory.StartNew(() =>
                {
                    Console.WriteLine("Nested task starting.");
                    Thread.SpinWait(5000000);
                    Console.WriteLine("Nested task completing.");
                    return 42;
                });

                // Parent will wait for this detached child.
                return nested.Result;
            });

            Console.WriteLine("Outer has returned {0}.", outer.Result);
        }

        public static void ParallelExample9()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent task executing.");
                var child = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Attached child starting.");
                    Thread.SpinWait(5000000);
                    Console.WriteLine("Attached child completing.");
                }, TaskCreationOptions.AttachedToParent);
            });
            parent.Wait();
            Console.WriteLine("Parent has completed.");
        }

        ////Вы также можете использовать метод AggregateException.Flatten, чтобы повторно
        ////    создать в одном экземпляре AggregateException все вложенные исключения,
        ////    полученные в нескольких экземплярах AggregateException от нескольких задач
        public static void ParallelExample10()
        {
            try
            {
                ExecuteTasks();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine("{0}:\n   {1}", e.GetType().Name, e.Message);
                }
            }
        }

        static void ExecuteTasks()
        {
            string path = @"C:\";
            List<Task> tasks = new List<Task>
                {
                    Task.Run(() =>
                    {
                        return Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                    }),

                    Task.Run(() =>
                    {
                        if (path == @"C:\")
                            throw new ArgumentException("The system root is not a valid path.");
                        return new string[] { ".txt", ".dll", ".exe", ".bin", ".dat" };
                    }),

                    Task.Run(() =>
                    {
                        throw new NotImplementedException("This operation has not been implemented.");
                    })
                };

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ae)
            {
                throw ae.Flatten();
            }
        }

        #region Sequential_Loop
        static void MultiplyMatricesSequential(double[,] matA, double[,] matB,
                                                double[,] result)
        {
            int matACols = matA.GetLength(1);
            int matBCols = matB.GetLength(1);
            int matARows = matA.GetLength(0);

            for (int i = 0; i < matARows; i++)
            {
                for (int j = 0; j < matBCols; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }
                    result[i, j] += temp;
                }
            }
        }
        #endregion

        #region Parallel_Loop
        static void MultiplyMatricesParallel(double[,] matA, double[,] matB, double[,] result)
        {
            int matACols = matA.GetLength(1);
            int matBCols = matB.GetLength(1);
            int matARows = matA.GetLength(0);

            // A basic matrix multiplication.
            // Parallelize the outer loop to partition the source array by rows.
            Parallel.For(0, matARows, i =>
            {
                for (int j = 0; j < matBCols; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }
                    result[i, j] = temp;
                }
            }); // Parallel.For
        }
        #endregion

        #region Main
        public static void ParallelExample11()
        {
            // Set up matrices. Use small values to better view 
            // result matrix. Increase the counts to see greater 
            // speedup in the parallel loop vs. the sequential loop.
            int colCount = 180;
            int rowCount = 2000;
            int colCount2 = 270;
            double[,] m1 = InitializeMatrix(rowCount, colCount);
            double[,] m2 = InitializeMatrix(colCount, colCount2);
            double[,] result = new double[rowCount, colCount2];

            // First do the sequential version.
            Console.Error.WriteLine("Executing sequential loop...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MultiplyMatricesSequential(m1, m2, result);
            stopwatch.Stop();
            Console.Error.WriteLine("Sequential loop time in milliseconds: {0}",
                                    stopwatch.ElapsedMilliseconds);

            // For the skeptics.
            OfferToPrint(rowCount, colCount2, result);

            // Reset timer and results matrix. 
            stopwatch.Reset();
            result = new double[rowCount, colCount2];

            // Do the parallel loop.
            Console.Error.WriteLine("Executing parallel loop...");
            stopwatch.Start();
            MultiplyMatricesParallel(m1, m2, result);
            stopwatch.Stop();
            Console.Error.WriteLine("Parallel loop time in milliseconds: {0}",
                                    stopwatch.ElapsedMilliseconds);
            OfferToPrint(rowCount, colCount2, result);

            // Keep the console window open in debug mode.
            Console.Error.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        #endregion

        #region Helper_Methods
        static double[,] InitializeMatrix(int rows, int cols)
        {
            double[,] matrix = new double[rows, cols];

            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = r.Next(100);
                }
            }
            return matrix;
        }

        private static void OfferToPrint(int rowCount, int colCount, double[,] matrix)
        {
            Console.Error.Write("Computation complete. Print results (y/n)? ");
            char c = Console.ReadKey(true).KeyChar;
            Console.Error.WriteLine(c);
            if (Char.ToUpperInvariant(c) == 'Y')
            {
                if (!Console.IsOutputRedirected) Console.WindowWidth = 180;
                Console.WriteLine();
                for (int x = 0; x < rowCount; x++)
                {
                    Console.WriteLine("ROW {0}: ", x);
                    for (int y = 0; y < colCount; y++)
                    {
                        Console.Write("{0:#.##} ", matrix[x, y]);
                    }
                    Console.WriteLine();
                }
            }
        }
        #endregion

    }


}