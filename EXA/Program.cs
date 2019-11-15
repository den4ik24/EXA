using System;

namespace EXA
{
    public class Program
    {
        public static void Main()
        {
            #region События
            Counter.RunningEvent();
            #endregion

            #region Сериализация
            Serialization.RunningSerialization();
            #endregion

            #region Свойства
            Properties.RunProperties();
            #endregion

            #region Приведение типов
            TypeСonversions.RunTypeСonversions();
            #endregion

            #region Потоки
            Threadings.RunThreadings();
            #endregion

            #region Параметры
            Parameters.RunParameters();
            #endregion

            #region Отражения
            Reflection.RunReflection1();
            Reflection.RunReflection2();
            Reflection.RunReflection3();
            Reflection.RunReflection4();
            #endregion

            #region Обобщения
            Generics.RunGenerics1();
            Generics.RunGenerics2();
            #endregion

            #region Методы расширения
            Extensions.RunExtensions();
            #endregion

            #region Массивы
            Arrays.RunArrays1();
            Arrays.RunArrays2();
            Arrays.RunArrays3();
            #endregion

            #region Лямбда
            Lambda.RunLambda();
            #endregion

            #region Исключения
            Exceptions.RunExceptions();
            #endregion

            #region Интерфейсы
            Interfaces.RunInterfaces1();
            Interfaces.RunInterfaces2();
            Interfaces.RunInterfaces3();
            #endregion

            #region Делегаты
            Delegates.RunDelegates1();
            Delegates.RunDelegates2();
            #endregion

            #region  Атрибуты
            Attributes.RunAttributes1();
            #endregion

            #region Асинхронные методы
            Asynchronous.RunAsynchronous();
            #endregion

            #region Nullable
            Nullable.RunNullable1();
            Nullable.RunNullable2();
            #endregion

            #region Параллелизм
            ParallelExample.ParallelExample1();
            ParallelExample.ParallelExample2();
            ParallelExample.ParallelExample3();
            ParallelExample.ParallelExample4();
            ParallelExample.ParallelExample5();
            ParallelExample.ParallelExample6();
            ParallelExample.ParallelExample7();
            ParallelExample.ParallelExample8();
            ParallelExample.ParallelExample9();
            ParallelExample.ParallelExample10();
            ParallelExample.ParallelExample11();
            #endregion

            #region Примеры
            Example.RunExample1();
            #endregion

        }

    }
    
}
