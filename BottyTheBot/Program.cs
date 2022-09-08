using ArchiveUnpacker;
using Downloading;
using FileHelpers;
using MVD;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;

while (true)
{
    var engine = new FileHelperAsyncEngine<Passp>();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Parser"].ConnectionString);
    con.Open();
    string sql = @"delete Passports";
    SqlCommand cmd = new SqlCommand(sql, con);
    cmd.ExecuteNonQuery();
    con.Close();

    Download.Loading();
    BZ2.Unpacking();

    using (engine.BeginReadFile(@"C:\Users\Dima\source\repos\BottyTheBot\BottyTheBot\bin\Debug\net6.0\list_of_expired_passports_decomp.csv"))
    {
        Console.WriteLine("Производится запись в базу данных, пожалуйста, подождите.");

        foreach (Passp pass in engine)
        {
            Conn.ConnToDb(pass);
        }
        Console.WriteLine("Запись в базу данных завершена.");
    }
    Thread.Sleep(1000 * 60 * 60 * 24 * 7);
}
