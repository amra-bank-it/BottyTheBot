using ArchiveUnpacker;
using CopyToDB;
using Downloading;
using FileHelpers;
using MVD;
using System.Configuration;
using System.Data.SqlClient;

while (true)
{
    DateTime date2, littime;
    date2 = DateTime.UtcNow;
    TimeSpan ts = new TimeSpan(03, 00, 00);
    littime = date2 + ts;
    Console.WriteLine("Программа запущена");
    Console.WriteLine(littime);

    var engine = new FileHelperAsyncEngine<Passp>();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Expired_Passports"].ConnectionString);
    con.Open();
    string sql = @"delete list_of_expired_passports_buffer";
    SqlCommand cmd = new SqlCommand(sql, con);
    cmd.CommandTimeout = 0;
    cmd.ExecuteNonQuery();
    con.Close();

    Download.Loading();
    BZ2.Unpacking();

    using (engine.BeginReadFile(@"list_of_expired_passports_decomp.csv"))
    {
        Console.WriteLine("Производится запись в буферную базу данных, пожалуйста, подождите.");

        foreach (Passp pass in engine)
        {
            Conn.ConnToDb(pass);
        }
        Console.WriteLine("Запись в буферную базу данных завершена.");
    }

    Copy.InsertToDB();

    Thread.Sleep(1000 * 60 * 60 * 24 * 7);
}
