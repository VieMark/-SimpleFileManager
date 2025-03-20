namespace SimpleFileManager;
using System;
using System.IO;

class FileManager
{
    public string Path = "Undefined"; 
    
    // Функция для определения пути
    public void NewPath(){
        Console.WriteLine("Прошу задайте путь для работы ( C:/example ) :");
        Path = Console.ReadLine();
    }

    // Функция для создания новых папок или каталогов
    public void CreatingFolder(){
        Console.WriteLine("Рабочая область остаётся прежней ? (+ -)");
        string bl = Console.ReadLine();
        if (bl == "+"){
            Console.WriteLine("Введите как будет называться папка  ( /folder ) :");
            string FolderName = Console.ReadLine();
            Directory.CreateDirectory(Path + FolderName);
            Console.WriteLine("Папка была успешно создана.");
        }
        else if (bl == "-"){
            Console.WriteLine("Прошу задайте путь для работы ( C:/example ) :");
            Path = Console.ReadLine();
            Console.WriteLine("Введите как будет называться папка  ( /folder ) :");
            string FolderName = Console.ReadLine();
            Directory.CreateDirectory(Path + FolderName);
            Console.WriteLine("Папка была успешно создана.");
        }
    }

    // Функция для создания новых файлов
    public void CreatingFile(){
        Console.WriteLine("Заданный путь остаётся прежним ? (+ -)");
        string bl = Console.ReadLine();
        if (bl == "+"){
            Console.WriteLine("Введите как будет называться файл ( /file.txt ) :");
            string FileName = Console.ReadLine();
            Directory.CreateDirectory(Path + FileName);
            Console.WriteLine("Файл был успешно создан.");
        }
        else if (bl == "-"){
            Console.WriteLine("Прошу задайте путь для работы ( C:/example ) :");
            Path = Console.ReadLine();
            Console.WriteLine("Введите как будет называться файл ( /file.txt ) :");
            string FolderName = Console.ReadLine();
            Directory.CreateDirectory(Path + FolderName);
            Console.WriteLine("Файл был успешно создан.");
        }
    }

    // Функция для просмотра содержимого папки
    public void FolderContents(){
        Console.WriteLine("Файлы : ");
        string[] Files = Directory.GetFiles(Path);
        foreach (string File in Files){
            Console.WriteLine(File);
        }
    }

    // Функция для вывода информации о файле 
    public void Info(){
        Console.WriteLine("Файл находиться в уже заданном пути ? (+ -) :");
        string bl = Console.ReadLine();
        if (bl == "+"){
            Console.WriteLine("Введите как называtncz файл ( /file.txt ) :");
            string FileName = Console.ReadLine();
            FileInfo fileInfo = new FileInfo(Path+FileName);
            if (fileInfo.Exists){
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
                DateTime FileLastDate = File.GetLastAccessTime(Path+FileName);
                Console.WriteLine("Изменен: " + FileLastDate);
            }
        }
        else if (bl == "-"){
            Console.WriteLine("Прошу задайте путь до нужного файла ( C:/example/file.txt ) :");
            string PathFile = Console.ReadLine();

            FileInfo fileInfo = new FileInfo(PathFile);
            if (fileInfo.Exists){
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
                DateTime FileLastDate = File.GetLastAccessTime(PathFile);
                Console.WriteLine("Изменен: " + FileLastDate);
            }
        
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
                if (manager.Path == "Undefined"){
                    Console.WriteLine("Прошу задайте путь до рабочей области(папка) ( C:/example ) :");
                    manager.Path = Console.ReadLine();
                }

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
                   manager.FolderContents();
                }

                else if (UserSelection == "4"){
                    manager.Info();
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