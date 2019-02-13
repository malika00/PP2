using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        public static bool IsPrime (int n)                              //Функция на проверку простых чисел
        {
            if (n == 1 || n == 0) return false;
            for(int i=2;i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../input.txt");            //Создаем Реадер
            string[] s = sr.ReadToEnd().Split();                              //создаем массив и делим строку по пробелу
            sr.Close();                                                       //Обязательно закрываем ридер 
            List<int> list = new List<int>();                                 //слздаем динамический массив 
            foreach(string a in s)                                            //пробигаемся по элементам массива 
            {
                int b = int.Parse(a);                                         //каждый элемент переводим в целоствное число 
                if (IsPrime(b))                                               //и проверияем на Prime
                    list.Add(b);                                              //если прайм закидываем в лист
            }
            StreamWriter sw = new StreamWriter("../../output.txt");           //создаем Райтер
            for (int i = 0; i < list.Count; i++)                              //пробегаемся по элементам листа
            {
                sw.Write(list[i] + " ");                                      //и записываем в новом файле с пробелом 
            }
            sw.Close();                                                       //Обязательно закрываем Райтер
            


        }
    }
}
