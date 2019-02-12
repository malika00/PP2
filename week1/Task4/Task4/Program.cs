using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //создаем число которое будет обозначать количество элементов в массиве 
            string[,] arr = new string[n, n];      //создаем двойной массив с размером n на n 
            for(int i = 0; i < n; i++)             // пробигаемся по массиву
            {
                for(int j = 0; j < n; j++)
                {
                    if (i == j)                   //если номер столбца и строки будут совподать тогда элемент массива будет равен [*]
                    {
                        arr[i,j] = "[*]";
                    }
                    if (i > j)                   //если номер столбца  будет больше строки тогда элемент массива будет равен [*]
                    {
                        arr[i, j] = "[*]";
                    }
                    
                }
                
            }
            for (int i = 0; i < n; i++)         //выводим массив
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i,j]);

                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
