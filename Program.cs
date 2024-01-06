namespace ConsoleApp15
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Пожалуйста, введите путь до папки:");
            string path = Console.ReadLine(); // читаем путь до папки из консоли

            if (Directory.Exists(path))
            {
                try
                {
                    long size = CalculateDirectorySize(path);
                    Console.WriteLine($"Размер папки: {size} байт");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при подсчете размера папки: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Папка по заданному пути не существует.");
            }
        }

        static long CalculateDirectorySize(string path)
        {
            long size = 0;
            var directory = new DirectoryInfo(path);

            foreach (var file in directory.GetFiles())
            {
                size += file.Length;
            }

            foreach (var dir in directory.GetDirectories())
            {
                size += CalculateDirectorySize(dir.FullName); // рекурсивный подсчет размера
            }

            return size;
        }
    }
}
