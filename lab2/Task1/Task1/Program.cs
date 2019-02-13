using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        public static bool Palindrom(string a)              //Функцтя для проверки на палиндром 
        {
            for (int i = 0; i < a.Length / 2; i++)
            {
                if (a[i] != a[a.Length - i - 1])
                {
                    return false;
                }

            }
            return true;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../input.txt"); //создаем streamReader
            string s = sr.ReadToEnd();                             //считываем инфу с файла переводим в string
            sr.Close();                                            //Закрываем reader
            if (Palindrom(s))                                      //провериям на условие палиндрома 
            {
                Console.WriteLine("YES");                          //Если проходит проверку тогда на консоль выводим слово "YES"

            }
            else
            {
                Console.WriteLine("NO");                           //если не проходит проверку тогда выводим "NO"
            }
            Console.ReadKey();
        }
    }
}
