using ICSharpCode.SharpZipLib.BZip2;

namespace ArchiveUnpacker
{
    internal class BZ2
    {
        public static void Unpacking()
        {
            FileInfo zipFileName = new FileInfo(@"list_of_expired_passports.csv.bz2");
            FileStream fileToDecompressAsStream = zipFileName.OpenRead();

            Console.WriteLine("Производится распаковка данных, пожалуйста, подождите.");
            string decompressedFileName = @"list_of_expired_passports_decomp.csv";
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
