public void ConnectWithHardcodedConnectionString()
{
    var connectionString = "Server=myServer;User Id=admin;Password=admin123;"; // Insecure: Hardcoded credentials
    Console.WriteLine("Connecting with hardcoded connection string.");

    // Simulate database connection
    Console.WriteLine("Connected to database using: " + connectionString);
}

// Solution

using System;

public class SecureDatabaseConnection
{
    public void Connect()
    {
        // Load the connection string securely (e.g., from environment variables)
        var server = Environment.GetEnvironmentVariable("DB_SERVER");
        var userId = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

        if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
        {
            Console.WriteLine("Failed to load database credentials.");
            return;
        }

        // Construct the connection string dynamically
        var connectionString = $"Server={server};User Id={userId};Password={password};";
        Console.WriteLine("Connecting to the database...");

        // Simulate database connection
        Console.WriteLine("Connected to database using a secure connection string.");
    }
}
