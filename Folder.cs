namespace FolderSizeCalculator;

internal class Folder
{
    internal double GetSize(string Path)
    {
        double size = 0;
        try
        {
            var directory = new DirectoryInfo(Path);
            if (directory.Exists)
            {
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    try
                    {
                        size += GetSize(dir.FullName);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine($"Недопустимое действие или недостаточно прав на выполнение для {dir.FullName}.");
                        continue;
                    }
                }
                FileInfo[] files = directory.GetFiles();
                if (files.Length > 0)
                {
                    foreach (FileInfo file in files)
                    {
                        try
                        {
                            size += file.Length;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine($"Недопустимое действие или недостаточно прав на выполнение для {file.FullName}.");
                            continue;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Указанный каталог {Path} не существует");
            }
        }
        catch (Exception)
        {
            throw;
        }
        return size;
    }
}
