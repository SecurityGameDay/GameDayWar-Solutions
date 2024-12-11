public void ReadFileLines(string userInput)
{
    // Reads all lines from a file based on unvalidated user input
    var lines = File.ReadAllLines(userInput);
    Console.WriteLine($"Read {lines.Length} lines from file: {userInput}");
}

// Solve the above vulnerability
using System;
using System.IO;

public void ReadFileLines(string userInput)
{
    try
    {
        // Define the base directory
        string baseDirectory = Path.GetFullPath("AllowedDirectory");

        // Combine and resolve the user input with the base directory
        string fullPath = Path.GetFullPath(Path.Combine(baseDirectory, userInput));

        // Validate that the resolved path is within the allowed directory
        if (!fullPath.StartsWith(baseDirectory, StringComparison.OrdinalIgnoreCase))
        {
            throw new UnauthorizedAccessException("Access to the file is denied.");
        }

        // Check if the file exists
        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException("The specified file does not exist.");
        }

        // Read the file lines securely
        var lines = File.ReadAllLines(fullPath);
        Console.WriteLine($"Read {lines.Length} lines from file: {fullPath}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
