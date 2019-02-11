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
            int n=int.Parse(Console.ReadLine());
            String[] arr = Console.ReadLine().Split();
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " " + arr[i]+ " ");
            }
        }
    }
}
