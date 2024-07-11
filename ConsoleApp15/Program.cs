using System;
using System.Text;

class Program
{
    public static void Menu()
    {
        Console.WriteLine("[1] Create new Folder");
        Console.WriteLine("[2] Show directory");
        Console.WriteLine("[3] Delete folder");
        Console.WriteLine("[4] Create new File");
        Console.WriteLine("[5] Delete file");
        Console.WriteLine("[6] Transfer file");
    }

    public static void CreateFolder(string folderName)
    {
        Directory.CreateDirectory($@"C:\Users\Qaniz_po25\Desktop\{folderName}");
    }

    public static void DeleteFolder(string folderName)
    {
        Directory.Delete($@"C:\Users\Qaniz_po25\Desktop\{folderName}", true);
    }

    public static void CreateFile(string fileName, string content)
    {
        using (FileStream fs = new FileStream($@"C:\Users\Qaniz_po25\Desktop\{fileName}.txt", FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = Encoding.Default.GetBytes(content);
            fs.Write(buffer, 0, buffer.Length);
        }
    }

    public static void DeleteFile(string fileName)
    {
        string filePath = $@"C:\Users\Qaniz_po25\Desktop\{fileName}.txt";

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine("File deleted");
        }
        else
        {
            Console.WriteLine("File not found!!");
        }
    }

    public static void FileTransfer(string sourceFile, string destinationFolder)
    {
        string sourceFilePath = $@"C:\Users\Qaniz_po25\Desktop\{sourceFile}.txt";
        string destinationFolderPath = $@"C:\Users\Qaniz_po25\Desktop\{destinationFolder}";

        if (File.Exists(sourceFilePath))
        {
            if (Directory.Exists(destinationFolderPath))
            {
                string destinationFilePath = Path.Combine(destinationFolderPath, $"{sourceFile}.txt");
                File.Move(sourceFilePath, destinationFilePath);
                Console.WriteLine("File transferred successfully");
            }
            else
            {
                Console.WriteLine("Destination folder not found!!");
            }
        }
        else
        {
            Console.WriteLine("Source file not found!!");
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Menu();
            Console.WriteLine("Choose your option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the new folder name: ");
                    string folderName = Console.ReadLine();
                    CreateFolder(folderName);
                    break;

                case 2:
                    Console.WriteLine(Directory.GetCurrentDirectory());
                    break;

                case 3:
                    Console.WriteLine("Enter the folder name to delete: ");
                    string folderToDelete = Console.ReadLine();
                    DeleteFolder(folderToDelete);
                    break;

                case 4:
                    Console.WriteLine("Enter the file name: ");
                    string newFileName = Console.ReadLine();
                    Console.Write("Enter file content: ");
                    string fileContent = Console.ReadLine();
                    CreateFile(newFileName, fileContent);
                    break;

                case 5:
                    Console.WriteLine("Enter the file name to delete: ");
                    string fileToDelete = Console.ReadLine();
                    DeleteFile(fileToDelete);
                    break;

                case 6:
                    Console.WriteLine("Enter the folder name to transfer to: ");
                    string destinationFolder = Console.ReadLine();
                    Console.WriteLine("Enter the file name to transfer: ");
                    string sourceFile = Console.ReadLine();
                    FileTransfer(sourceFile, destinationFolder);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear(); // Clear console for the next iteration
        }
    }
}
