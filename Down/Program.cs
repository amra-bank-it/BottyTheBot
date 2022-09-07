using System.Net;

using (var client = new WebClient())
using (var completedSignal = new AutoResetEvent(false))
{
    client.DownloadFileCompleted += (s, e) =>
    {
        Console.WriteLine("Загрузка завершена.");
        completedSignal.Set();
    };
    Console.WriteLine("Производится загрузка данных, пожалуйста, подождите.");
    client.DownloadProgressChanged += (s, e) => Console.WriteLine($"Выполнено {e.ProgressPercentage}%");
    client.DownloadFileAsync(new Uri("https://проверки.гувм.мвд.рф/upload/expired-passports/list_of_expired_passports.csv.bz2"), "list_of_expired_passports.csv.bz2");
    completedSignal.WaitOne();
}