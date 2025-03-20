namespace SimpleFileManager;
using System;
using System.IO;
using System.Xml;

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
        try{
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
        else{
            Console.WriteLine("выбрать можно только - или +");
        }
        }
        catch (Exception ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine("Возникла Ошибка!!!");
        }
    }

    // Функция для создания новых файлов
    public void CreatingFile(){
        try{
        Console.WriteLine("Заданный путь остаётся прежним ? (+ -)");
        string bl = Console.ReadLine();
        if (bl == "+"){
            Console.WriteLine("Введите как будет называться файл ( /file.txt ) :");
            string FileName = Console.ReadLine();
            Directory.CreateDirectory(Path + FileName);
            Console.WriteLine("Файл был успешно создан.");
        }
        else if (bl == "-"){
            Console.WriteLine("Прошу задайте путь для работы ( C:/folder ) :");
            Path = Console.ReadLine();
            Console.WriteLine("Введите как будет называться файл ( /file.txt ) :");
            string FolderName = Console.ReadLine();
            Directory.CreateDirectory(Path + FolderName);
            Console.WriteLine("Файл был успешно создан.");
        }
        }
        catch (Exception ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine("Возникла Ошибка!!!");
        }
        
    }

    // Функция для просмотра содержимого папки
    public void FolderContents(){
        Console.WriteLine("Файлы : ");
        string[] Files = Directory.GetFiles(Path);
        foreach (string File in Files){
            Console.WriteLine(File);
        }
        Console.WriteLine("Подкаталоги : ");
        string[] Folders = Directory.GetDirectories(Path);
        foreach (string dir in Folders){
            Console.WriteLine(dir);
        }
    }

    // Функция для вывода информации о файле 
    public void InfoFl(){
        try{
        Console.WriteLine("Файл находиться в уже заданном пути ? (+ -) :");
        string bl = Console.ReadLine();
        if (bl == "+"){
            Console.WriteLine("Введите как называется файл ( /file.txt ) :");
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
            Console.WriteLine("Прошу задайте путь до нужного файла ( C:/folder/file.txt ) :");
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
        catch (Exception ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine("Возникла Ошибка!!!");
        }
    }

    // Функция для вывода инфы про папку
    public void InfoFd(){
        try{
            DirectoryInfo FolderInfo = new DirectoryInfo(Path);
            Console.WriteLine($"Название каталога: { FolderInfo.Name}");
            Console.WriteLine($"Время создания каталога: { FolderInfo.CreationTime}");
            string[] files = System.IO.Directory.GetFiles(Path, "*.*", System.IO.SearchOption.AllDirectories);
            long sum = 0;
            for(int i = 0; i< files.Length;i++){
            FileInfo fi = new FileInfo(files[i]);
                sum=sum+fi.Length;
            }
            Console.WriteLine($"Размер: {sum}");
        }
        catch{
            Console.WriteLine("Возникла ошибка !");
        }

    }

    // Функция для переноса или копирования файла из одной папки в другую
    public void CopyFile(){
        try{
        

        Console.WriteLine("Что именно вы хотите ?");
        Console.WriteLine("(1) - копирование файла в другой каталог");
        Console.WriteLine("(2) - перенос файла в другой каталог");
        Console.WriteLine("(-) - назад");
        string choice = Console.ReadLine();
        if(choice == "-"){Console.WriteLine("Вы вернулись к меню выбора.");}
        else if(choice=="1"){
            Console.WriteLine("Введите путь в котором находится нужный файл ( C:/folder/file.txt ) :");
            string Path_old = Console.ReadLine();
            FileInfo file = new FileInfo(Path_old);
            Console.WriteLine("Введите путь в который будет помещён новый файл ( C:/folder/file2.txt ) :");
            string Path_new = Console.ReadLine();
            Console.WriteLine("Если файл с таким названием уже соществует перезаписать его ? (+ -)");
            string rewrite = Console.ReadLine();
            if (rewrite == "+"){
                if (file.Exists){
                    file.CopyTo(Path_new, true);      
                }
            }
            else if (rewrite == "-"){
                if (file.Exists){
                    file.CopyTo(Path_new, false);      
                }
            }
        }
        else if(choice=="2"){
            Console.WriteLine("Введите путь в котором находится нужный файл ( C:/folder/file.txt ) :");
            string Path_old  = Console.ReadLine();
            FileInfo file = new FileInfo(Path_old);
            Console.WriteLine("Введите путь в который будет помещён новый файл ( C:/folder/file.txt ) :");
            string Path_new = Console.ReadLine();
            Console.WriteLine("Если файл с таким названием уже соществует перезаписать его ? (+ -)");
            string rewrite = Console.ReadLine();
            if (rewrite == "+"){
                if (file.Exists){
                    file.MoveTo(Path_new, true);      
                }
            }
            else if (rewrite == "-"){
                if (file.Exists){
                    file.MoveTo(Path_new, false);      
                }
            }
        }
        }
        catch (Exception ex){
        Console.WriteLine(ex.Message);
        Console.WriteLine("Возникла Ошибка!!!");
        }
    }


    // Функция для переноса каталога из одной папки в другую
    public void CopyFolder(){
        try{ 
        Console.WriteLine("Введите путь в котором находится нужная папка ( C:/folder ) :");
        string Path_old  = Console.ReadLine();
        Console.WriteLine("Введите путь в который будет помещён новый файл ( C:/folder2 ) :");
        Console.WriteLine("Новый каталог не должен существовать !");
        string Path_new = Console.ReadLine();
        DirectoryInfo dirInfo = new DirectoryInfo(Path_old);
        if (dirInfo.Exists && !Directory.Exists(Path_new)){
            dirInfo.MoveTo(Path_new);
        }
        
        }
        catch (Exception ex){
        Console.WriteLine(ex.Message);
        Console.WriteLine("Возникла Ошибка!!!");
        }
    }

    // Функция для удаления файлов
    public void DeleteFile(){
        try{
        Console.WriteLine("Файл находиться в уже заданном пути ? (+ -) :");
        string bl = Console.ReadLine();
        if (bl == "+"){
            Console.WriteLine("Введите как называется файл ( /file.txt ) :");
            string FileName = Console.ReadLine();
            FileInfo fileD = new FileInfo(Path + FileName);
            Console.WriteLine($"Вы уверены что хотите удалить файл ? (+ -)");
            string check = Console.ReadLine();
            if (check=="+"){
                if (fileD.Exists) {
                fileD.Delete();
                Console.WriteLine("Файл успешно удалён.");
                }
            }
            else if (check == "-"){
                Console.WriteLine("Вы отменили удаление.");
            }
        }
        else if (bl == "-"){
            Console.WriteLine("Задайте путь до нужного файла ( C:/folder/file.txt ) :");
            string PathFile = Console.ReadLine();
            FileInfo fileD = new FileInfo(PathFile);
            Console.WriteLine($"Вы уверены что хотите удалить файл ? (+ -)");
            string check = Console.ReadLine();
            if(check == "+"){
                if (fileD.Exists) {
                fileD.Delete();
                Console.WriteLine("Файл успешно удалён.");
                }
            }
            else if (check == "-"){Console.WriteLine("Вы отменили удаление.");}
        }
        
        }
        catch (Exception ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine("Возникла Ошибка!!!");
        }
    }

    // Функция для удаления сразу всех файлов из папки
    public void DeletFolder(){
        try{
        Console.WriteLine("Вы хотите удалить файлы вместе с каталогом ? (+ -)");
        string j = Console.ReadLine();
        Console.WriteLine("Файлы находиться в уже заданном пути ? (+ -) :");
        string bl = Console.ReadLine();
        if (bl == "+"){
            if (j == "+"){
                Console.WriteLine($"Вы уверены что хотите удалить файлы ? (+ -)");
                string check = Console.ReadLine();
                if (check == "+"){Directory.Delete(Path, true);}
                else if(check == "-"){Console.WriteLine("Вы отменили удаление.");}
            }
            else if (j == "-"){
                Console.WriteLine($"Вы уверены что хотите удалить файлы ? (+ -)");
                string check = Console.ReadLine();
                if (check == "+"){
                    string[] picList = Directory.GetFiles(Path, "*.jpg");
                    string[] txtList = Directory.GetFiles(Path, "*.txt");
                    string[] pdfList = Directory.GetFiles(Path, "*.pdf");
                    foreach (string f in txtList){
                        File.Delete(f);
                    }
                    foreach (string f in picList){
                        File.Delete(f);
                    }
                    foreach (string f in pdfList){
                        File.Delete(f);
                    }
                    Console.WriteLine("Файлы удалёны.");
                }
                else if (check=="-"){Console.WriteLine("Вы отменили удаление.");}
            }
        }
        else if (bl == "-"){
            Console.WriteLine("Прошу задайте путь до нужной папки с файлами ( C:/folder ) :");
            string PathFolder = Console.ReadLine();
            if (j == "+"){
                Console.WriteLine($"Вы уверены что хотите удалить файлы ? (+ -)");
                string check = Console.ReadLine();
                if (check =="+"){Directory.Delete(PathFolder, true); }
                else if (check=="-"){Console.WriteLine("Вы отменили удаление.");}
            }
            else if (j == "-"){
                Console.WriteLine($"Вы уверены что хотите удалить файлы ? (+ -)");
                string check = Console.ReadLine();
                if (check=="+"){
                    string[] picList = Directory.GetFiles(PathFolder, "*.jpg");
                    string[] txtList = Directory.GetFiles(PathFolder, "*.txt");
                    string[] pdfList = Directory.GetFiles(PathFolder, "*.pdf");

                    foreach (string f in txtList){
                        File.Delete(f);
                    }
                    foreach (string f in picList){
                        File.Delete(f);
                    }
                    foreach (string f in pdfList){
                        File.Delete(f);
                    }
                    Console.WriteLine("Файлы удалёны.");
                }
                else if (check=="-"){Console.WriteLine("Вы отменили удаление.");}
            }
        }       
        }
        catch (Exception ex){
            Console.WriteLine(ex.Message);
            Console.WriteLine("Возникла Ошибка!!!");
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
                    Console.WriteLine("Прошу задайте путь до рабочей области(каталога) ( C:/folder/ ) :");
                    manager.Path = Console.ReadLine();
                }

                Console.WriteLine("Что вы хотите сделать ?");
                Console.WriteLine("(cd) - Изменить путь");
                Console.WriteLine("(1) - Создать каталог");
                Console.WriteLine("(2) - Создать файл");
                Console.WriteLine("(3) - Просмотреть содержимое каталога");
                Console.WriteLine("(4) - Узнать информацию о файле");
                Console.WriteLine("(5) - Узнать информацию о каталоге");
                Console.WriteLine("(6) - Копирование файла");
                Console.WriteLine("(7) - Перенос каталога");
                Console.WriteLine("(8) - Удалить файл");
                Console.WriteLine("(9) - Удалить все файлы из каталога");
                Console.WriteLine("(exit) - Завершить программу");
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
                    manager.InfoFl();
                }
                else if (UserSelection == "5"){
                    manager.InfoFd();
                }
                else if (UserSelection == "6"){
                    manager.CopyFile();
                }
                else if (UserSelection == "7"){
                    manager.CopyFolder();
                }
                else if (UserSelection == "8"){
                    manager.DeleteFile();
                }
                else if (UserSelection == "9"){
                    manager.DeletFolder();
                }
                else if (UserSelection == "exit"){
                    flag = false;
                }
                else {
                    Console.WriteLine("Выберите что-то из представленных вариантов.");
                }
            }
        }
        catch (Exception ex){
            Console.WriteLine("Возникла ошибка !");
            Console.WriteLine(ex.Message);
        }
    }
}