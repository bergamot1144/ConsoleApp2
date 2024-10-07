using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string[] files = { "file1", "file2", "file3", "file4", "file5" };
        Random random = new Random();
        Stopwatch timer = new Stopwatch();

        Console.WriteLine("Начало загрузки файлов...");
        timer.Start();

        
        var downloadTasks = files.Select(async file =>
        {
            int downloadTime = random.Next(1, 6); 
            Console.WriteLine($"Начата загрузка файла {file}");
            await Task.Delay(downloadTime * 1000); 
            Console.WriteLine($"Загрузка файла {file} завершена за {downloadTime} секунд");
        });

        
        await Task.WhenAll(downloadTasks);

        timer.Stop();
        Console.WriteLine($"Общее время загрузки всех файлов: {timer.Elapsed.Seconds} секунд");
    }
}
