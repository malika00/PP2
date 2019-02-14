using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/malik/Desktop/pp2/lab2/Task4/KymaRodnoy";     //приравниваем путь до папки в стринг
            string file = "KymaBrat.txt";                                         //название нового файла
            path = System.IO.Path.Combine(path, file);                            //создаем файл в заданной папке   


            System.IO.File.WriteAllText(path, "Kyma the best");                   //пишем что то в файл

            string path1 = "C:/Users/malik/Desktop/pp2/lab2/Task4/KymaZuer";      //приравниваем путь до второй папки в стринг
            string newfile = System.IO.Path.Combine(path1, file);                 //создаем второй файл с названием первого файла 
            System.IO.File.Copy(path, newfile, true);                             //копируем содержимое с первой папки 

            File.Delete(path);                                                    //удаляем первый файл 

        }
    }
}
