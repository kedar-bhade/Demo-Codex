namespace UserManagementApi.DAL;
using UserManagementApi.Model;
using System.Data;
using MySql.Data.MySqlClient;

public class CredentialsDataAccess
{
    public static string conString = @"server=localhost; port=3306; user=root; password=root; database=userinfo";
    public static void RegisterUser(Credential cred)
    {
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = $"insert into credentials(username, password) values('{cred.username}', '{cred.password}')";
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static bool ValidateUser(Credential cred)
    {
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = $"select count(*) from credentials where username='{cred.username}' and password='{cred.password}'";
            MySqlCommand command = new MySqlCommand(query, con);
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        finally
        {
            con.Close();
        }
    }
}
