using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EXA
{
    public class сериализация
    {
        public static void Main()
        {
            //создание графа объектов для последующей сериализации в поток
            var objectGraph = new List<string> {"AAA", "BBB", "CCC", "DDD"};
            Stream stream = SerializableToMemory(objectGraph);

            //Обнуляем все для данного примера
            stream.Position = 0;
            objectGraph = null;

            //Десериализация объектов и проверка их работоспособности
            objectGraph = (List<string>)
                DeserializeFromMemory(stream);
            foreach (var s in objectGraph)
                Console.WriteLine(s);
        }

        private static MemoryStream SerializableToMemory (object objectGraph)
        {

     //Конструирование потока, который будет содержать сериализованные объекты
            MemoryStream stream = new MemoryStream();

            //Задание форматирования при сериализации
            BinaryFormatter formatter = new BinaryFormatter();

            //Заставляем модуль форматирования сериализовать объекты в поток
            formatter.Serialize(stream, objectGraph);

            //Возвращение потока сериализованных объектов вызывающему методу
            return stream;
        }

        private static object DeserializeFromMemory(Stream stream)
        {
            //Задание форматирования при сериализации
            BinaryFormatter formatter = new BinaryFormatter();

            //Заставляем модуль форматирования десериализовать объекты из потока
            return formatter.Deserialize(stream);
        }
    }
}
