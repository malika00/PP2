using System;
using System.Collections.Generic;
using System.IO;


namespace Lab3
{
    

    class Program
    {
        class FarManager
        {
            public int cursor;
            public string path;
            public int sz;
            public bool ok;
            DirectoryInfo directory = null;
            FileSystemInfo curentfs = null;
            public FarManager()
            {
                cursor = 0;

            }
            public FarManager(string path)
            {
                this.path = path;
                cursor = 0;
                directory = new DirectoryInfo(path);
                sz = directory.GetFileSystemInfos().Length;
                ok = true;
            }
            public void Color(FileSystemInfo fs,int index)
            {
                if(cursor == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    curentfs = fs;
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
             public void SZ()
            {
                directory = new DirectoryInfo(path);
                FileSystemInfo[] fs = directory.GetFileSystemInfos();
                sz = fs.Length;
                for(int i = 0; i < fs.Length; i++)
                {
                    if (fs[i].Name[0] == '.')
                        sz--;
                }
            }
             public void Show()
             {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                directory = new DirectoryInfo(path);
                FileSystemInfo[] fs = directory.GetFileSystemInfos();
                for(int i = 0,k=0; i < fs.Length; i++)
                {
                    if(ok==false && fs[i].Name[0] == '.')
                    {
                        continue;
                    }
                    Color(fs[i],k);
                    Console.WriteLine(fs[i].Name);
                    k++;
                }

             }
            public void Up()
            {
    
                cursor--;
                if (cursor < 0)
                    cursor = sz - 1;
                
                
            }
            public void Down()
            { 
                cursor++;
                if (cursor == sz)
                    cursor = 0;
            }
            public void Enter()
            {
                if (curentfs.GetType() == typeof(DirectoryInfo))
                {
                    cursor = 0;
                    path = curentfs.FullName;
                }
                if (curentfs.GetType() == typeof(FileInfo))
                {
                    path = curentfs.FullName;
                    StreamReader sr = new StreamReader(curentfs.FullName);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    string s = sr.ReadToEnd();
                    sr.Close();
                    Console.WriteLine(s);
                    Console.ReadKey();

                }
            }
            public void Delete()
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
            public void R()
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
            public void Start()
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
            string path = "C:/Users/malik/Desktop/far";
            FarManager far = new FarManager(path);
            far.Start();

            

        }

    }

}
