public void GetUserData(int id)
{
    // SQL injection vulnerability
    string connectionString = "YourConnectionStringHere";
    string query = $"SELECT * FROM Users WHERE id={id}";

    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (var command = new SqlCommand(query, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"User ID: {reader["Id"]}, Username: {reader["Username"]}");
                }
            }
        }
    }
}

// Solve the above vulnerability
public void GetUserData(int id)
{
    string connectionString = "YourConnectionStringHere";
    string query = "SELECT * FROM Users WHERE Id = @Id";

    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (var command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Id", id);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"User ID: {reader["Id"]}, Username: {reader["Username"]}");
                }
            }
        }
    }
}
