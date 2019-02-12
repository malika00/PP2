using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student                                     //создем класс Студента
    {
        public string name;                           //который имеет 3 параметра: имя,айди,год обучения 
        public string id;
        public int year;

        public Student()                              //пустой конструктор 
        {

        }

        public Student(string name, string id)       //конструктор который имеет два параметра
        {
            this.name = name;
            this.id = id;
            year = 1;                                //и если мы отправляем два параметра тогда год будет равен 1
        }
        public Student(string name, string id, int year) //конструктор который имеет все 3 параметра
        {
            this.name = name;
            this.id = id;
            this.year = year;

        }


        
        public void Print()    //Функция для вывода данных
        {
            Console.WriteLine("Name:" + name + ", Id:" + id + ", A year of study:" + (++year)); //вывод информаций студента + имплимент от года обучения
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Student st = new Student("Malika", "18BD");
            //st.Print();

            string[] inf = Console.ReadLine().Split(); //Считываем данные о студенте с консоли
            Student st = new Student(inf[0], inf[1]);  //создаем экземпляр от Студента с этими данными
            st.Print();                                //вызфваем функцию для выводда данных


            Console.ReadKey();
        }
    }
}
