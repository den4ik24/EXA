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
        public static void RunParallelExample1()
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

        public static void RunParallelExample2()
        {
            Thread.CurrentThread.Name = "Main";
            Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA."));
            Console.WriteLine($"Hello from thread '{Thread.CurrentThread.Name}'.");
            taskA.Wait();
        }

        public static void RunParallelExample3()
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

        public static void RunParallelExample4()
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

        public static void RunParallelExample5()
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

        public static void RunParallelExample6()
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

        public static void RunParallelExample7()
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

        public static void RunParallelExample8()
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

        public static void RunParallelExample9()
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
        public static void RunParallelExample10()
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
        public static void RunParallelExample11()
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

        public static void RunParallelExample12()
        {
            FactorialAsync12();
            Console.WriteLine("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"квадрат числа равен {n * n}");
            Console.WriteLine("Конец метода Main");
            Console.Read();
        }

        static void Factorial12()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(8000);
            Console.WriteLine($"Факториал равен{result}");
        }
        static async void FactorialAsync12()
        {
            Console.WriteLine("начало метода FactorialAsync");
            await Task.Run(Factorial12);
            Console.WriteLine("Конец метода FactorialAsync");
        }


        public static void RunParallelExample13()
        {
            ReadWriteAsync();

            Console.WriteLine("Некоторая работа");

        }
        static async void ReadWriteAsync()
        {
            string s = "Hello world! One step at a time";

            // hello.txt - файл, который будет записываться и считываться
            using (StreamWriter writer = new StreamWriter("hello1.txt", false))
            {
                await writer.WriteLineAsync(s);  // асинхронная запись в файл
            }
            using StreamReader reader = new StreamReader("hello1.txt");
            string result = await reader.ReadToEndAsync();  // асинхронное чтение из файла
            Console.WriteLine(result);
        }


        public static void RunParallelExample14()
        {
            FactorialAsync14(5);
            FactorialAsync14(6);
            Console.WriteLine("Некоторая работа");
            Console.Read();
        }
        static void Factorial14(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Thread.Sleep(3000);
            Console.WriteLine($"Факториал равен {result}");
        }
        // определение асинхронного метода
        static async void FactorialAsync14(int n)
        {
            await Task.Run(() => Factorial14(n));
        }


        public static void RunParallelExample15()
        {
            FactorialAsync15(5);
            FactorialAsync15(6);
            Console.Read();
        }
        static int Factorial15(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        // определение асинхронного метода
        static async void FactorialAsync15(int n)
        {
            int x = await Task.Run(() => Factorial15(n));
            Console.WriteLine($"Факториал равен {x}");
        }


        public static void RunParallelExample16()
        {
            FactorialAsync(5);
            FactorialAsync(6);
            Console.WriteLine("Некоторая работа");
            Console.Read();
        }
        static void Factorial16(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Thread.Sleep(5000);
            Console.WriteLine($"Факториал равен {result}");
        }
        // определение асинхронного метода
        static async void FactorialAsync(int n)
        {
            await Task.Run(() => Factorial16(n));
        }


        public static void RunParallelExample17()
        {
            var task = Task.Factory.StartNew(Work);
            task.ContinueWith(t => Console.WriteLine($"Задача выполнена. Результат: {task.Result} "));
            Console.WriteLine("Основной поток завершен.");
            Console.ReadLine();
            A();
            B();
        }
        static bool Work()
        {
            Console.WriteLine("Выполнение задачи...");
            Thread.Sleep(3000);
            return true;
        }

        static Task A()
        {
            return Task.Run(() => Work());
        }

        static async Task B()
        {
            await Task.Run(Work);
        }


        public static void RunParallelCancellationToken1()
        {
            CancellationTokenSource cancelTokenSource1 = new CancellationTokenSource();
            CancellationToken token1 = cancelTokenSource1.Token;
            int number = 6;

            Task task1 = new Task(() =>
            {
                int result = 1;
                for (int i = 1; i <= number; i++)
                {
                    if (token1.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }

                    result *= i;
                    Console.WriteLine($"Факториал числа {i} равен {result}");
                    Thread.Sleep(5000);
                }
            });
            task1.Start();

            Console.WriteLine("Введите Y для отмены операции или другой символ для ее продолжения:");
            string s = Console.ReadLine();
            if (s == "Y")
                cancelTokenSource1.Cancel();

            Console.Read();
        }


        public static void RunParallelCancellationToken2()
        {
            CancellationTokenSource cancelTokenSource2 = new CancellationTokenSource();
            CancellationToken token2 = cancelTokenSource2.Token;

            Task task2 = new Task(() => FactorialF(5, token2));
            task2.Start();

            Console.WriteLine("Введите Y для отмены операции или любой другой символ для ее продолжения:");
            string s = Console.ReadLine();
            if (s == "Y")
                cancelTokenSource2.Cancel();

            Console.ReadLine();
        }
        static void FactorialF(int x, CancellationToken token2)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                if (token2.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }

                result *= i;
                Console.WriteLine($"Факториал числа {i} равен {result}");
                Thread.Sleep(5000);
            }
        }


        public static void RunParallelCancellationToken3()
        {
            CancellationTokenSource cancelTokenSource3 = new CancellationTokenSource();
            CancellationToken token3 = cancelTokenSource3.Token;

            new Task(() =>
            {
                Thread.Sleep(400);
                cancelTokenSource3.Cancel();
            }).Start();

            try
            {
                Parallel.ForEach(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 },
                                        new ParallelOptions { CancellationToken = token3 }, Factorial20);
                // или так
                //Parallel.For(1, 8, new ParallelOptions { CancellationToken = token3 }, Factorial20);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Операция прервана");
            }
            finally
            {
                cancelTokenSource3.Dispose();
            }

            Console.ReadLine();
        }
        static void Factorial20(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал числа {x} равен {result}");
            Thread.Sleep(3000);
        }


        public static void RunParallelTaskCompletionSource()
        {
            TaskCompletionSource<int> tcs1 = new TaskCompletionSource<int>();
            Task<int> t1 = tcs1.Task;

            // Start a background task that will complete tcs1.Task
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                tcs1.SetResult(15);
            });

            // The attempt to get the result of t1 blocks the current thread
            //until the completion source gets signaled.
            // It should be a wait of ~1000 ms.
            Stopwatch sw = Stopwatch.StartNew();
            int result = t1.Result;
            sw.Stop();

            Console.WriteLine($"(ElapsedTime={sw.ElapsedMilliseconds}): t1.Result={result} (expected 15) ");


            // Alternatively, an exception can be manually set on a TaskCompletionSource.Task
            TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>();
            Task<int> t2 = tcs2.Task;

            // Start a background Task that will complete tcs2.Task with an exception
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                tcs2.SetException(new InvalidOperationException("SIMULATED EXCEPTION"));
            });

            // The attempt to get the result of t2 blocks the current thread
            //until the completion source gets signaled with either a result or an exception.
            // In either case it should be a wait of ~1000 ms.
            sw = Stopwatch.StartNew();
            try
            {
                result = t2.Result;

                Console.WriteLine("t2.Result succeeded. THIS WAS NOT EXPECTED.");
            }
            catch (AggregateException e)
            {
                Console.Write($"(ElapsedTime={sw.ElapsedMilliseconds}");
                Console.WriteLine("The following exceptions have been thrown by t2.Result: (THIS WAS EXPECTED)");
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    Console.WriteLine($"\n-------------------------------------------------\n{e.InnerExceptions[j]}");
                }
            }
        }
    }
}
