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
            DateTime dateTimeNow = DateTime.Now; 
            command.Parameters.AddWithValue("@PASSP_SERIES", pass.PASSP_SERIES);
            command.Parameters.AddWithValue("@PASSP_NUMBER", pass.PASSP_NUMBER);
            command.Parameters.AddWithValue("@CUR_TIME", dateTimeNow);
            try
            {
                conect.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Произошла ошибка при передаче данных в базу. Код ошибки: " + e.ToString());
            }
            finally
            {
                conect.Close();
            }
        }
    }
}