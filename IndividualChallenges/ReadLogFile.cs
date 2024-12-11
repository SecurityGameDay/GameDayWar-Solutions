public void ReadLogFile(string filename)
{
    string filePath = "C:\\logs\\" + filename;
    string content = File.ReadAllText(filePath);
    Console.WriteLine($"File Content: {content}");
}

// solve the above vulnerability

public void ReadLogFile(string filename)
{
    string filePath = "C:\\logs\\" + filename;
    if (UserHasAdminAccess())
    {
        string content = File.ReadAllText(filePath);
        Console.WriteLine($"File Content: {content}");
    }
    else
    {
        Console.WriteLine("You do not have access to read the logs.");
    }
}