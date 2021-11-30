using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FileWorks
{
  
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь:");
            //var path = Console.ReadLine(); 
            var path = @"C:\Users\3213897\OneDrive - Jabil\Documents";
            Console.WriteLine("Введите искомую маску:");
            //var mask = Console.ReadLine();
            var mask = "*.*";
            //Range og dates
            DateTime From = new DateTime(2021, 4, 5,0,0,0);
            DateTime To = new DateTime(2021, 12, 31, 0, 0, 0);
            //Список всех файлов с искомой маской
            string[] files = Directory.GetFiles(path, mask, SearchOption.AllDirectories);
            //Поиск файлов удовлетворяющих маске и диапазону дат и запись в лог файл
            for (int i = 0; files.Length > i; i++)
            {
                string str = Path.GetFileName(files[i]);
                FileStream fs = new FileStream("log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                DateTime lastChange = File.GetLastWriteTime(files[i]);
                if (lastChange >= From && lastChange <= To)

                    sw.WriteLine(str + " Was created" + lastChange + ",");
                sw.Close();
            }

            
           

        }

    }
}
