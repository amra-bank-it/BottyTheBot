using CopyToDB;
using MVD;
using System.Configuration;
using System.Data.SqlClient;

public class Conn
{
    public static void ConnToDb(Passp pass)
    {
        if (pass.PASSP_SERIES != "PASSP_SERIES" && pass.PASSP_NUMBER != "PASSP_NUMBER")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Expired_Passports"].ConnectionString);
            string query = "INSERT INTO list_of_expired_passports_buffer (PASSP_SERIES, PASSP_NUMBER, CUR_TIME) VALUES (@PASSP_SERIES, @PASSP_NUMBER, @CUR_TIME)";
            SqlCommand command = new SqlCommand(query, con);

            DateTime date2, littime;
            date2 = DateTime.UtcNow;
            TimeSpan ts = new TimeSpan(03, 00, 00);
            littime = date2 + ts;
            command.Parameters.AddWithValue("@PASSP_SERIES", pass.PASSP_SERIES);
            command.Parameters.AddWithValue("@PASSP_NUMBER", pass.PASSP_NUMBER);
            command.Parameters.AddWithValue("@CUR_TIME", littime);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Произошла ошибка при передаче данных в базу. Код ошибки: " + e.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}