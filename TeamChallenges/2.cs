using System;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Text;

class VulnerableCLI
{
    // Hardcoded Credentials (Vulnerability #1)
    private const string connectionString = "Server=myServer;Database=myDB;User Id=admin;Password=admin123;";
    private const string remoteServer = "http://remoteserver.com/api/upload";
    private const string apiKey = "hardcoded-api-key";

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Insecure CLI!");

        // Prompt user for login credentials
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        // Log user input (Vulnerability #6)
        File.AppendAllText("log.txt", $"Login attempt: {username}, Password: {password}\n");

        // SQL Injection (Vulnerability #2)
        string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("Login successful!");
                PerformFileOperation();
                UploadDataToServer(username, password);
            }
            else
            {
                Console.WriteLine("Login failed.");
            }
        }
    }

    static void PerformFileOperation()
    {
        Console.Write("Enter filename to modify: ");
        string fileName = Console.ReadLine();

        // Unvalidated Input and Insecure File Operations (Vulnerabilities #3, #5)
        string filePath = "C:\\SecureData\\" + fileName;
        File.AppendAllText(filePath, "Insecure data appended.\n");

        Console.WriteLine($"Data appended to {filePath}");
    }

    static void UploadDataToServer(string username, string password)
    {
        HttpClient client = new HttpClient();

        // Unencrypted Communication (Vulnerability #4)
        string payload = $"{{\"username\":\"{username}\",\"password\":\"{password}\"}}";
        HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

        HttpResponseMessage response = client.PostAsync(remoteServer + "?apiKey=" + apiKey, content).Result;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Data uploaded successfully.");
        }
        else
        {
            Console.WriteLine("Failed to upload data.");
        }
    }
}
