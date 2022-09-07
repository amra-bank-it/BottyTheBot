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
            string query = "INSERT INTO Passports (PASSP_SERIES, PASSP_NUMBER) VALUES (@PASSP_SERIES, @PASSP_NUMBER)";
            SqlCommand command = new SqlCommand(query, conect);
            command.Parameters.AddWithValue("@PASSP_SERIES", pass.PASSP_SERIES);
            command.Parameters.AddWithValue("@PASSP_NUMBER", pass.PASSP_NUMBER);
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