namespace SimpleFileManager;
using System;
using System.IO;

class FileManager
{
    public void CreatingFolder(){
        Console.WriteLine("Введите где вы хотите создать папку ( C:/folder/ ) :");
        string FolderPath = Console.ReadLine();
        Console.WriteLine("Введите как будет называться папка :");
        string FolderName = Console.ReadLine();
        Directory.CreateDirectory(FolderPath + FolderName);

    }

    public void CreatingFile(){
        Console.WriteLine("Введите где вы хотите создать файл ( C:/folder/ ):");
        string FilePath = Console.ReadLine();
        Console.WriteLine("Введите как будет называться файл :");
        string FileName = Console.ReadLine();
        Directory.CreateDirectory(FilePath + FileName);
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
                Console.WriteLine("Что вы хотите сделать ?");
                Console.WriteLine("(1) - Создать папку");
                Console.WriteLine("(2) - Создать файл");
                Console.WriteLine("(3) - Просмотреть содержимое папки");
                Console.WriteLine("(4) - Узнать информацию о файле");
                Console.WriteLine("(5) - Перенести файл");
                Console.Write("Ваш выбор - ");

                int UserSelection = int.Parse(Console.ReadLine());

                if (UserSelection == 1){
                    manager.CreatingFolder();
                }

                else if (UserSelection == 2){
                    
                }

                else if (UserSelection == 3){
                    
                }

                else if (UserSelection == 4){
                    
                }

                else if (UserSelection == 5){
                    
                }

                else if (UserSelection == 6){
                    
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