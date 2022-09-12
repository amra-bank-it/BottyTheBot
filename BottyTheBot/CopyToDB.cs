using System.Configuration;
using System.Data.SqlClient;

namespace CopyToDB
{
    public class Copy
    {
        public static void InsertToDB()
        {
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["Parser"].ConnectionString);
            SqlCommand command1 = new SqlCommand("delete Passports", conection);
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Parser"].ConnectionString);
            SqlCommand command2 = new SqlCommand("INSERT INTO Passports SELECT* FROM Passports_Buffer", connect);

            try
            {
                conection.Open();
                command1.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Произошла ошибка при передаче данных в базу. Код ошибки: " + e.ToString());
            }
            finally
            {
                conection.Close();
            }
            try
            {
                connect.Open();
                command2.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Произошла ошибка при передаче данных в базу. Код ошибки: " + e.ToString());
            }
            finally
            {
                connect.Close();
            }
        }
    }
}