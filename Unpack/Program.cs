
using ICSharpCode.SharpZipLib.BZip2;

FileInfo fileToBeZipped = new FileInfo(@"C:\Users\Dima\source\repos\BottyTheBot\Down\bin\Debug\net6.0\list_of_expired_passports.csv");
FileInfo zipFileName = new FileInfo(string.Concat(fileToBeZipped.FullName, ".bz2"));

using (FileStream fileToDecompressAsStream = zipFileName.OpenRead())
{
    string decompressedFileName = @"C:\Users\Dima\source\repos\BottyTheBot\Down\bin\Debug\net6.0\list_of_expired_passports.csv";
    using (FileStream decompressedStream = File.Create(decompressedFileName))
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
}