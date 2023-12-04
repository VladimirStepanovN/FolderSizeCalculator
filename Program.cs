namespace FolderSizeCalculator;

internal class Program
{
    internal static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к каталогу:");
        string? Path = Console.ReadLine();
        if (!string.IsNullOrEmpty(Path) && !string.IsNullOrWhiteSpace(Path))
        {
            try
            {
                Folder folder = new();
                double folderSize = folder.GetSize(Path);
                Console.WriteLine($"Размер каталога: {folderSize} байт.");
                Console.ReadKey();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Недопустимая часть пути к каталогу.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Путь или имя файла превышает максимальную длину, определенную системой.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Путь к каталогу не указан.");
        }
    }
}