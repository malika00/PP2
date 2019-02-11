using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static bool Prime(int n) 
        {

            if (n == 1 || n == 0) return false;
            for(int i = 2; i < n; i++)
            {

                if (n % i == 0) return false;
       
            }
            return true;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arr = Console.ReadLine().Split();
            int[] par = new int[n];
            for(int i = 0; i < n; i++)
            {
                par[i] = int.Parse(arr[i]);
            }
            List<int> list = new List<int>();
            for(int i = 0; i < n; i++)
            {
                if (Prime(par[i]))
                {
                    list.Add(par[i]);
                }
            }
            Console.WriteLine(list.Count);
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] +" ");

            }
            Console.ReadKey();
        }
    }
}
