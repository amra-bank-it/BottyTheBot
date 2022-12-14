using System.Net;

namespace Downloading
{
    internal class Download
    {
        public static void Loading()
        {
            using (var client = new WebClient())
            using (var completedSignal = new AutoResetEvent(false))
            {
                client.DownloadFileCompleted += (s, e) =>
                {
                    Console.WriteLine("Загрузка завершена.");
                    completedSignal.Set();
                    DateTime date2, littime;
                    date2 = DateTime.UtcNow;
                    TimeSpan ts = new TimeSpan(03, 00, 00);
                    littime = date2 + ts;
                    Console.WriteLine(littime);
                };
            Console.WriteLine("Производится загрузка данных, пожалуйста, подождите.");
                client.DownloadProgressChanged += (s, e) =>
                    {
                        double dProgress = (((double)e.BytesReceived / e.TotalBytesToReceive) * 100.0);
                        Console.WriteLine($"Данные загружены на {dProgress} %");
                    };
                client.DownloadFileAsync(new Uri("https://проверки.гувм.мвд.рф/upload/expired-passports/list_of_expired_passports.csv.bz2"), "list_of_expired_passports.csv.bz2");
                completedSignal.WaitOne();
            }
        }
    }
}

