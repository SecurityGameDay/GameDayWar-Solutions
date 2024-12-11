public void GetUserByUsername(string username)
{
    // SQL injection vulnerability
    string connectionString = "YourConnectionStringHere";
    string query = "SELECT * FROM Users WHERE Username = '" + username + "'";

    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (var command = new SqlCommand(query, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"User: {reader["Username"]}");
                }
            }
        }
    }
}

// SOlve the above vulnerability

public void GetUserByUsername(string username)
{
    string connectionString = "YourConnectionStringHere";
    string query = "SELECT * FROM Users WHERE Username = @Username";

    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (var command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Username", username);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"User: {reader["Username"]}");
                }
            }
        }
    }
}
