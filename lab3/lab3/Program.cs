using System;
using System.Collections.Generic;
using System.IO;


namespace Lab3
{
    class Layer
    {

        public FileSystemInfo[] Content   // Создаем массив в который будем класть всё что есть в директории 
        {
            get;
            set;
        }

        public int SelectedItem // выбранный элемент то есть подсвеченный 
        {
            get;
            set;
        }

        public void Draw() // метод отрисовки 
        {
            int j = 1; // для визуального счетчика в консоли 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear(); // очистка консоли перед выводом новой директории или предыдущего стека 

            for (int i = 0; i < Content.Length; ++i) // отрисовка курсора, файла и папок 
            {
                if (i == SelectedItem) // отрисовка курсора 
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (Content[i].GetType() == typeof(DirectoryInfo)) // если это директория подствечиваем белым 
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else Console.ForegroundColor = ConsoleColor.Yellow; // в другом случае желтым 

                Console.Write(j + ". "); // визуальный счетчик 
                j++;
                Console.WriteLine(Content[i].Name); // вывод файлов и директории на консоль  

            }

        }
    }


    enum ViewMode // создаем енумерэйтор  
    {
        ShowDirContent,   // при этом значении показывает директорию 
        ShowFileContent   // при этом значении показывает файл 
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("C:/Users/malik/Desktop");  // наша главная директория 
            Stack<Layer> history = new Stack<Layer>(); // стэк в котором хранится вся история по принципу LIFO 

            history.Push(               // добавить контент в стэк 
                new Layer
                {
                    Content = dir.GetFileSystemInfos()
                }
            );

            ViewMode viewMode = ViewMode.ShowDirContent;    // режим просмотра меняем на показ  директории 

            bool esc = false; // булевая переменная которая поначалу будет отрицательной 
            while (!esc)
            {
                if (viewMode == ViewMode.ShowDirContent) // если включен режим прсомотра директории 
                {
                    try  // обрабатываем исключение про которое сказал ассистент 
                    {
                        history.Peek().Draw();  // пытаемся вызвать стек 
                    }
                    catch { Environment.Exit(0); } // закрываем консоль при обнаружении исключения 

                    history.Peek().Draw(); // в случае без исключения выводим весь контент 
                }

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(); // создаем переменную клавиш которая считывает клавишу с консоли 

                switch (consoleKeyInfo.Key)  // создаем условный оператор  
                {
                    case ConsoleKey.M: // если нажали М 

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear(); // чистим консоль 

                        string name = Console.ReadLine(); // Вводим новое имя для файла или папки 

                        int x3 = history.Peek().SelectedItem; // захватываем индекс выбранного курсором файла или папки 

                        FileSystemInfo fileSystemInfo3 = history.Peek().Content[x3]; // берем его по индексу  

                        if (fileSystemInfo3.GetType() == typeof(DirectoryInfo)) // проверяем файл ли он 
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo3 as DirectoryInfo;   // создаем вторую такую же директорию
                            Directory.Move(fileSystemInfo3.FullName, directoryInfo.Parent + "/" + name); // изначальный путь файла, 
                            //путь на который нужно поменять , изза того что после преспоследнего слеша мы меняем  
                            // его имя то берем его парент то есть без имени директории и присоединяем имя которое мы ввели в консоль   
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos(); // ну и конечно же изза того что мы поменяли 
                            // имя файла нужно теперь его контент изменить в истории  
                        }

                        else
                        {
                            FileInfo fileInfo = fileSystemInfo3 as FileInfo; // если это не папка а файл 

                            File.Move(fileSystemInfo3.FullName, fileInfo.Directory.FullName + "/" + name); // так же прям меняем имя 

                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos(); //  опять изменяем его в стэке 
                        }

                        break;

                    case ConsoleKey.Delete: // клавиша удаления 

                        int x2 = history.Peek().SelectedItem; // сохранения индекса курсора 

                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2]; // передаем контент курсора 

                        history.Peek().SelectedItem--; // перемещаем курсора на индекс ниже 

                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo)) // если директория  
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo2 as DirectoryInfo;  //  копируем директорию удаляемой папки 

                            Directory.Delete(fileSystemInfo2.FullName, true);  // удаляем папку 

                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos(); // кидаем в стэк только его парентс  
                                                                                                // так как файла уже нет 
                        }

                        else // если файл 
                        {
                            FileInfo fileInfo = fileSystemInfo2 as FileInfo;  // копируем удаляемый файл 

                            File.Delete(fileSystemInfo2.FullName); // удаляем файл 

                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos(); // получаем экземпляр родительского каталога 
                        }

                        break;

                    case ConsoleKey.UpArrow: // вверх 

                        history.Peek().SelectedItem--; // индекс минус 

                        if (history.Peek().SelectedItem == -1) // если вышло за границы массива 
                        {

                            history.Peek().SelectedItem = history.Peek().Content.Length - 1; // переводим в конец 
                        }

                        break;

                    case ConsoleKey.DownArrow: // вниз 

                        history.Peek().SelectedItem++; // индекс плюс 
                        if (history.Peek().SelectedItem == history.Peek().Content.Length) // если вышло за границы массива 
                        {

                            history.Peek().SelectedItem = 0; // переводим в начало курсор 
                        }

                        break;

                    case ConsoleKey.Enter: // открывание  

                        int x = history.Peek().SelectedItem; // сохраняем индекс выбранного курсором файла 

                        FileSystemInfo fileSystemInfo = history.Peek().Content[x]; // берем его как файла а не как индекс 

                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo)) // если это директория 
                        {
                            viewMode = ViewMode.ShowDirContent; // показываем внутренность  

                            DirectoryInfo selectedDir = fileSystemInfo as DirectoryInfo; //  переменная селектед равна выбранной папке
                            history.Push(new Layer { Content = selectedDir.GetFileSystemInfos() }); // добавляем в контент содержимое папки 
                                                                                                    // и этот контент кидаем в стэк 
                        }

                        else
                        {
                            viewMode = ViewMode.ShowFileContent; // если это файл 

                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read)) // создание переменной 
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White; // белый цвет как в блокноте  
                                    Console.Clear(); // очищение консоли  

                                    Console.ForegroundColor = ConsoleColor.Black;

                                    Console.WriteLine(sr.ReadToEnd()); // вывести весь текст 
                                }

                            }

                        }

                        break;

                    case ConsoleKey.Backspace: // возвращение назад  

                        if (viewMode == ViewMode.ShowDirContent) // режим директории  
                        {
                            history.Pop();   // удаление нынешнего слоя 
                        }

                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black; // сделать черным 
                            Console.Clear(); // очистить 

                            Console.ForegroundColor = ConsoleColor.White; // покрасить в белое 

                            viewMode = ViewMode.ShowDirContent; // режим просмотра директории 
                        }

                        break;

                    case ConsoleKey.Escape: // выход 
                        esc = true;
                        break;
                }

            }

        }

    }

}
