using System;
using System.IO;
using System.Data.SqlClient;

namespace InsecureConsoleApp
{
    class Program
    {
        private static string connectionString = "Server=myServer;Database=myDB;User Id=admin;Password=admin123;";

        static void Main(string[] args)
        {
            // 1. SQL Injection (Unsanitized user input)
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'"; // SQL Injection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("Login Successful");
                }
                else
                {
                    Console.WriteLine("Login Failed");
                }
            }

            // 2. Insecure File Handling (Writing to a sensitive file)
            File.WriteAllText("C:\\SensitiveData\\user_data.txt", "Sensitive Information"); // Sensitive file location

            // 3. Hardcoded Credentials (Vulnerable to compromise)
            string adminPassword = "admin123"; // Hardcoded admin password
            if (adminPassword == "admin123")
            {
                Console.WriteLine("Admin access granted");
            }
            else
            {
                Console.WriteLine("Admin access denied");
            }

            // 4. Logging Sensitive Information
            File.AppendAllText("login_attempts.txt", $"{username} attempted to log in at {DateTime.Now}\n"); // Logging sensitive data
        }
    }
}
