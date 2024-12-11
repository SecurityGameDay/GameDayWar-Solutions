public void DeleteOrder(int orderId)
{
    // SQL injection vulnerability
    string connectionString = "YourConnectionStringHere";
    string query = $"DELETE FROM Orders WHERE Id = {orderId}";

    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (var command = new SqlCommand(query, connection))
        {
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"Deleted {rowsAffected} rows.");
        }
    }
}

// Solution
using System;
using System.Data.SqlClient;

public void DeleteOrder(int orderId)
{
    string connectionString = "YourConnectionStringHere";
    string query = "DELETE FROM Orders WHERE Id = @orderId";  // Parameterized query

    try
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            
            // Create the command and add the parameter
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@orderId", orderId);  // Safely add the parameter

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Deleted {rowsAffected} rows.");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
