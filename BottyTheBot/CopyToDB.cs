using System.Configuration;
using System.Data.SqlClient;

namespace CopyToDB
{
    public class Copy
    {
        public static void InsertToDB()
        {
            SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["Expired_Passports"].ConnectionString);
            SqlCommand command1 = new SqlCommand("delete list_of_expired_passports", conection);
            SqlConnection connected = new SqlConnection(ConfigurationManager.ConnectionStrings["Expired_Passports"].ConnectionString);
            SqlCommand command2 = new SqlCommand("SELECT * FROM list_of_expired_passports_buffer ORDER BY CUR_TIME ASC", connected);
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["Expired_Passports"].ConnectionString);
            SqlCommand command3 = new SqlCommand("INSERT INTO list_of_expired_passports SELECT* FROM list_of_expired_passports_buffer", connect);
            
            try
            {
                conection.Open();
                command1.CommandTimeout = 0;
                command1.ExecuteNonQuery();
                Console.WriteLine("Удаление данных из базы завершено");

            }
            catch (SqlException e)
            {
                Console.WriteLine("Произошла ошибка при удалении данных из базы. Код ошибки: " + e.ToString());
            }
            finally
            {
                conection.Close();
            }
            try
            {
                conection.Open();
                command2.CommandTimeout = 0;
                command2.ExecuteNonQuery();
                Console.WriteLine("Сортировка данных по дате завершена");

            }
            catch (SqlException e)
            {
                Console.WriteLine("Произошла ошибка при сортировке данных по дате. Код ошибки: " + e.ToString());
            }
            finally
            {
                conection.Close();
            }
            try
            {
                connect.Open();
                command3.CommandTimeout = 0;
                command3.ExecuteNonQuery();
                Console.WriteLine("Передача данных в базу завершена");

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