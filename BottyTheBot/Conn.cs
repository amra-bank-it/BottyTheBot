using MVD;
using System.Configuration;
using System.Data.SqlClient;

public class Conn
{
    public static void ConnToDb(Passp pass)
    {
        if (pass.PASSP_SERIES != "PASSP_SERIES" && pass.PASSP_NUMBER != "PASSP_NUMBER")
        {
            SqlConnection conect = new SqlConnection(ConfigurationManager.ConnectionStrings["Parser"].ConnectionString);
            string query = "INSERT INTO Pasports (PASSP_SERIES, PASSP_NUMBER, CUR_TIME) VALUES (@PASSP_SERIES, @PASSP_NUMBER, @CUR_TIME)";
            SqlCommand command = new SqlCommand(query, conect);
            DateTime date2, littime;
            date2 = DateTime.UtcNow;
            TimeSpan ts = new TimeSpan(03, 00, 00);
            littime = date2 + ts;
            Console.WriteLine(littime);
            command.Parameters.AddWithValue("@PASSP_SERIES", pass.PASSP_SERIES);
            command.Parameters.AddWithValue("@PASSP_NUMBER", pass.PASSP_NUMBER);
            command.Parameters.AddWithValue("@CUR_TIME", littime);
            try
            {
                conect.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Произошла ошибка при п ередаче данных в базу. Код ошибки: " + e.ToString());
            }
            finally
            {
                conect.Close();
            }
        }
    }
}