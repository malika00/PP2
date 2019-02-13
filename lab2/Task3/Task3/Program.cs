using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        public static void PS(int l)                                //Функция для вывода пробелов
        {
            for(int i = 0; i < l; i++)
            {
                Console.Write("   ");
            }
        }
        public static void Print(DirectoryInfo dir,int level)      //Функция для вывода папок и файлов 
        {
            foreach (FileInfo f in dir.GetFiles())                 //пробигаемся по всем файлам директорий 
            {
                PS(level);                                         //выводим отступ 
                Console.WriteLine(f.Name);                         //выводим имя файла
            }
            foreach (DirectoryInfo d in dir.GetDirectories())      //пробигаемся по всем директориям 
            {
                PS(level);                                         //выводим отступ
                Console.WriteLine(d.Name);                         //выводим имя папки
                Print(d, level + 1);                               //запускаем функцию для того что бы вывести все что внитри этой папки 
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("C:/Users/malik/Desktop/pp2"); //отправляем путь до папки 
            Print(dir,0);                                                        //запускаем функцию
            Console.ReadKey();
        }

        
    }
}
