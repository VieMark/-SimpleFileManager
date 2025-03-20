namespace SimpleFileManager;
using System;
using System.IO;

class FileManager
{
    public string Path = "Undefined"; 

    public void NewPath(){
        Console.WriteLine("Прошу задайте путь для работы ( C:/example ) :");
        Path = Console.ReadLine();
    }

    public void CreatingFolder(){
        Console.WriteLine("Рабочая область остаётся прежней ? (+ -)");
        string bl = Console.ReadLine();
        if (bl == "+"){
            Console.WriteLine("Введите как будет называться папка  ( /folder ) :");
            string FolderName = Console.ReadLine();
            Directory.CreateDirectory(Path + FolderName);
        }
        else if (bl == "-"){
            Console.WriteLine("Прошу задайте путь для работы ( C:/example ) :");
            Path = Console.ReadLine();
            Console.WriteLine("Введите как будет называться папка  ( /folder ) :");
            string FolderName = Console.ReadLine();
            Directory.CreateDirectory(Path + FolderName);
        }
    }

    public void CreatingFile(){
        Console.WriteLine("Рабочая область остаётся прежней ? (+ -)");
        string bl = Console.ReadLine();
        if (bl == "+"){
            Console.WriteLine("Введите как будет называться файл ( /file ) :");
            string FileName = Console.ReadLine();
            Directory.CreateDirectory(Path + FileName);
        }
        else if (bl == "-"){
            Console.WriteLine("Прошу задайте путь для работы ( C:/example ) :");
            Path = Console.ReadLine();
            Console.WriteLine("Введите как будет называться файл ( /file ) :");
            string FolderName = Console.ReadLine();
            Directory.CreateDirectory(Path + FolderName);
        }
    }

    public void FolderContents(){
        Console.WriteLine("Файлы : ");
        string[] Files = Directory.GetFiles(Path);
        foreach (string File in Files)
        {
            Console.WriteLine(File);
        }
    }



}

class Program
{
    static void Main(string[] args)
    {
        var manager = new FileManager();

        try{
            Boolean flag = true;
            while (flag){
                Console.WriteLine("Вас приветствует ваш помошник в работе с файлами !");

                Console.WriteLine("Прошу задайте путь до рабочей области(папка) ( C:/example ) :");
                manager.Path = Console.ReadLine();

                Console.WriteLine("Что вы хотите сделать ?");
                Console.WriteLine("(cd) - изменить путь");
                Console.WriteLine("(1) - Создать папку");
                Console.WriteLine("(2) - Создать файл");
                Console.WriteLine("(3) - Просмотреть содержимое папки");
                Console.WriteLine("(4) - Узнать информацию о файле");
                Console.WriteLine("(5) - Перенести файл");
                Console.WriteLine("Ваш выбор - ");

                string UserSelection = Console.ReadLine();

                if (UserSelection == "cd"){
                    manager.NewPath();
                }

                else if (UserSelection == "1"){
                    manager.CreatingFolder();
                }

                else if (UserSelection == "2"){
                    manager.CreatingFile();
                }

                else if (UserSelection == "3"){
                   
                }

                else if (UserSelection == "4"){
                    
                }

                else if (UserSelection == "5"){
                    
                }

                else if (UserSelection == "6"){
                    
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Что-то пошло не так !");
            Console.WriteLine(ex.Message);
        }
    }
}