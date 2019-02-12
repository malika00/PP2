using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static bool Prime(int n)             //функция для проверки на Prime
        {

            if (n == 1 || n == 0) return false;     //если цифра равна 1 или 0 то функция возварщяет False
                                                    //если не проходит первое условие идет дальше
            for(int i = 2; i < n; i++)              //цикл котороый пробегается с 2 до цифры
            {

                if (n % i == 0) return false;       //если n делится на цифру без остатка тогда функция возвращяет False
       
            }
            return true;                            //и если все проверки до этого не сработают тогда функция возвращяет True
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());     //Водим цифру с концоли,которая обозначает количество элементов в масиве 
            string[] arr = Console.ReadLine().Split(); //разделяем стороку элементов по пробелу
            int[] par = new int[n];                    //создаем массив int чисел
            for(int i = 0; i < n; i++)                 //Пробегаемся от i до розмера нашего массива
            {
                par[i] = int.Parse(arr[i]);            //пробегаемся по элементам массива arr,переводим в int, и приравниваем его к элементу массива par
            }
            List<int> list = new List<int>();          //Создаем динамический массив
            for(int i = 0; i < n; i++)     
            {
                if (Prime(par[i]))                     //пробигаемся по всем элементам массива,и проверяем по условию
                {
                    list.Add(par[i]);                  // если элемент проходит проверку по Prime тогда он добавляется в наш динамический массив
                }
            }
            Console.WriteLine(list.Count);             // выводим размер динамического массива
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] +" ");          // пробигаемся по всем элементам и выводим в кансоль с пробелом 

            }
            Console.ReadKey();                        //для того что бы экран не закрывался сразу,а ждал пока мы не нажмем на любую кнопку
        }
    }
}
