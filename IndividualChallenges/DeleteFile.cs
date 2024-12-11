public void DeleteFile(string userInput)
{
    // Deletes a file based on unvalidated user input
    File.Delete(userInput); 
    Console.WriteLine($"Deleted file: {userInput}");
}

// Solution

using System;
using System.IO;

public void DeleteFile(string userInput)
{
    // Base directory where deletions are allowed
    string baseDirectory = "C:\\SafeFiles";

    try
    {
        // Validate user input
        if (string.IsNullOrWhiteSpace(userInput) || userInput.Contains(".."))
        {
            throw new ArgumentException("Invalid file name.");
        }

        // Construct the full file path
        string fullPath = Path.Combine(baseDirectory, userInput);

        // Ensure the full path is within the base directory
        if (!fullPath.StartsWith(baseDirectory, StringComparison.OrdinalIgnoreCase))
        {
            throw new UnauthorizedAccessException("Access to this file is not allowed.");
        }

        // Check if the file exists
        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File does not exist: {fullPath}");
            return;
        }

        // Delete the file
        File.Delete(fullPath);
        Console.WriteLine($"Deleted file: {fullPath}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
