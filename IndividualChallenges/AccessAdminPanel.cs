public void AccessAdminPanel(string username)
{
    if (username == "admin") // Hardcoded username for admin
    {
        Console.WriteLine("Access to Admin Panel Granted!");
    }
    else
    {
        Console.WriteLine("Access Denied.");
    }
}

// Solve the above vulnerability using environemt variables
public void AccessAdminPanel_Solution(string username)
{
    if (username == Environment.GetEnvironmentVariable("ADMIN_USERNAME")) // Get the username from environment variable
    {
        Console.WriteLine("Access to Admin Panel Granted!");
    }
    else
       Console.WriteLine("Access Denied.");
}
