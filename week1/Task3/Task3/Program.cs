using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());         //создаем int число которое булет обозначать количесто элементов в массиве
            String[] arr = Console.ReadLine().Split();   //Ситываем число с консоли и делим их по пробелу
            int[] a = new int[n];                        //создаем массив целостных чисел
            for(int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]);               //пробешаемся по элементам массива arr,переводим в int,и приравниваем элементу массива a
            }
            List<int> list = new List<int>();           //создаем диномический массив которых будет хранить элементы с дубликатамии 

            for(int i = 0; i < a.Length; i++)
            {
                list.Add(a[i]);                         // пробегаемся по элементам массива a, и добавляем его в диномический массив с дубликатом 
                list.Add(a[i]);
            }
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");         //выводим элемента массива с пробелом 
            }

            Console.ReadKey();

        }
    }
}
