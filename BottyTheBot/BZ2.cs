using ICSharpCode.SharpZipLib.BZip2;

namespace ArchiveUnpacker
{
    internal class BZ2
    {
        public static void Unpacking()
        {
            FileInfo fileToBeZipped = new FileInfo(@"C:\Users\Dima\source\repos\BottyTheBot\BottyTheBot\bin\Debug\net6.0\list_of_expired_passports.csv");
            FileInfo zipFileName = new FileInfo(string.Concat(fileToBeZipped.FullName, ".bz2"));
            FileStream fileToDecompressAsStream = zipFileName.OpenRead();

            Console.WriteLine("Производится распаковка данных, пожалуйста, подождите.");
            string decompressedFileName = @"C:\Users\Dima\source\repos\BottyTheBot\BottyTheBot\bin\Debug\net6.0\list_of_expired_passports.csv";
            FileStream decompressedStream = File.Create(decompressedFileName);
            {
                try
                {
                    BZip2.Decompress(fileToDecompressAsStream, decompressedStream, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Распаковка завершена.");
        }
    }
}
