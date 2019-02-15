using System;
using System.Collections.Generic;
using System.IO;


namespace Lab3
{
    

    class Program
    {
        class FarManager                                                 //создаем класс Фарманаджера
        {
            public int cursor;                                            
            public string path;
            public int sz;                                               //размер вывединых папок 
            public bool ok;                                              //для крывания скрытых файлов 
            DirectoryInfo directory = null;
            FileSystemInfo curentfs = null;                              //инфа про файл на котором стоит курсор
            public FarManager()                                          //пустой конструктор
            {
                cursor = 0;

            }
            public FarManager(string path)                               //конструктор с один параметром 
            {
                this.path = path;
                cursor = 0;
                directory = new DirectoryInfo(path);
                sz = directory.GetFileSystemInfos().Length;
                ok = true;
            }
            public void Color(FileSystemInfo fs,int index)               //функция для сцвета строчек 
            {
                if(cursor == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    curentfs = fs;                                       //приравниваем инфу про файл если курсор с индексом файла совпадают 
                }
                else if(fs.GetType() == typeof(DirectoryInfo))
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Magenta;

                }
            }
             public void SZ()                                           //функция для подчета размера директорий на консоли
            {
                directory = new DirectoryInfo(path);
                FileSystemInfo[] fs = directory.GetFileSystemInfos();   //массив директорий 
                sz = fs.Length;
                for(int i = 0; i < fs.Length; i++)                      //пробигаемся по всем файлам 
                {
                    if (fs[i].Name[0] == '.')                           //которые проходят проверку,если название файла начинается с "." 
                        sz--;                                           //тогда  размер уменьшается 
                }
            }
             public void Show()                                         //функция для вывода директорий
             {
                Console.BackgroundColor = ConsoleColor.Black;           //каждый раз при движений курсора стираем все что в консоли 
                Console.Clear();
                directory = new DirectoryInfo(path);
                FileSystemInfo[] fs = directory.GetFileSystemInfos();
                for(int i = 0,k=0; i < fs.Length; i++)                  //пробилаемся про всем директориям создаем переменную к которая пробигается по нескрытым файлам 
                {
                    if(ok==false && fs[i].Name[0] == '.')               //проверка на скрытый файл
                    {
                        continue;                                       //если он скрытый то он не выводится 
                    }
                    Color(fs[i],k);                                     //отправляем в функцию для покраски 
                    Console.WriteLine(fs[i].Name);
                    k++;                                                //к увеличивается только тогда когда вывелся нескрытый файл 
                }

             }
            public void Up()                                            //функция для поднятия курсора вверх
            {
    
                cursor--;
                if (cursor < 0)
                    cursor = sz - 1;
                
                
            }
            public void Down()                                          //функция для поднятия курсора вниз
            { 
                cursor++;
                if (cursor == sz)
                    cursor = 0;
            }
            public void Enter()                                        //функция для открывание 
            {
                if (curentfs.GetType() == typeof(DirectoryInfo))       
                {
                    cursor = 0;
                    path = curentfs.FullName;
                }
                if (curentfs.GetType() == typeof(FileInfo))
                {
                    path = curentfs.FullName;
                    StreamReader sr = new StreamReader(curentfs.FullName); //для вывода созеджимого файла 
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    string s = sr.ReadToEnd();
                    sr.Close();
                    Console.WriteLine(s);
                    Console.ReadKey();

                }
            }
            public void Delete()                                          //для удаления 
            {
                if (curentfs.GetType() == typeof(DirectoryInfo))
                {
                    cursor = 0;
                    Directory.Delete(curentfs.FullName);
                }
                else
                {
                    cursor = 0;
                    File.Delete(curentfs.FullName);
                }
            }
            public void R()                                              //функция для ринейминга
            {
                Console.Clear();
                Console.WriteLine("Enter new name:");
                string newname = Console.ReadLine();
                Console.Clear();
                string newpath = Path.Combine(directory.FullName, newname);
                if (curentfs.GetType() == typeof(DirectoryInfo))
                {
                    Directory.Move(curentfs.FullName, newpath);
                }
                else
                {
                    File.Move(curentfs.FullName, newpath);
                }
            }
            public void Start()                                           //основная функция для запуска
             {
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                while(consoleKey.Key != ConsoleKey.Escape)
                {
                    SZ();
                    Show();
                    consoleKey = Console.ReadKey();
                    if (consoleKey.Key == ConsoleKey.UpArrow)
                    {
                        Up();
                    }
                    if(consoleKey.Key == ConsoleKey.DownArrow)
                    {
                        Down();
                    }
                    if(consoleKey.Key == ConsoleKey.LeftArrow)
                    {
                        cursor = 0;
                        ok = true;

                    }
                    if(consoleKey.Key == ConsoleKey.RightArrow)
                    {
                        ok = false;
                        cursor = 0;
                    }
                    if (consoleKey.Key == ConsoleKey.Enter)
                    {
                        Enter();
                    }
                    if(consoleKey.Key== ConsoleKey.Backspace)
                    {
                        cursor = 0;
                        path = directory.Parent.FullName;
                    }
                    if (consoleKey.Key == ConsoleKey.Delete)
                    {
                        Delete();
                    }
                    if (consoleKey.Key == ConsoleKey.R)
                    {
                        R();
                    }

                }
                
                

             }
            
        }

        static void Main(string[] args)
        {
            string path = "C:/Users/malik/Desktop/far";                      //задаем путь
            FarManager far = new FarManager(path);                           //создаем обьект класса ФарМанаджер 
            far.Start();                                                     //запускаем оснавную функцию 

            

        }

    }

}
