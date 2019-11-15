using System;
using System.IO;

namespace EXA
{
    public class Exceptions
    {
        public static void RunExceptions()
        {
            Console.Write("Введите строку (не больше 6-ти символов): ");
            string message = Console.ReadLine();
            try
            {
                if (message.Length > 6)
                {
                    throw new Exception("Длина строки больше 6 символов");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
            Console.Read();
        }

        private void ReadData(string pathname)
        {

            FileStream fs = null;
            try
            {
                fs = new FileStream(pathname, FileMode.Open);
            }
            catch (IOException)
            {

            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

    }
}
