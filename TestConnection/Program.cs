using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost:3306;Database=db_swagger_menu;Uid=root;Pwd=Root123;";

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection successful!");
                // Perform additional database operations if needed
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Connection failed: " + ex.Message);
        }

        Console.ReadLine();
    }
}
