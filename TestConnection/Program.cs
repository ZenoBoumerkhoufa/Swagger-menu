using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=ZENO-LAPTOP\\SQLEXPRESS;Database=db_swagger_menu;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection successful!");
                // Perform additional database operations if needed
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        Console.ReadLine();
    }
}
