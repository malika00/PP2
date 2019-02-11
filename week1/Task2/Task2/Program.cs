using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        public string name;
        public string id;
        public int year;

        public Student()
        {

        }

        public Student(string name, string id)
        {
            this.name = name;
            this.id = id;
            year = 1;
        }
        public void Print()
        {
            Console.WriteLine("Name:" + name + ", Id:" + id + ", A year of study:" + (++year));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
                Student st = new Student("Malika", "18BD");
                st.Print();
            Console.ReadKey();
        }
    }
}
