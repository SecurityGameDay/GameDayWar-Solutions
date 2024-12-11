public void DeleteDirectory(string folderName)
{
    // Deletes a directory based on unvalidated user input
    Directory.Delete("C:\\Sensitive\\" + folderName, true);
    Console.WriteLine($"Deleted directory: C:\\Sensitive\\{folderName}");
}

// Solution

using System;
using System.IO;

public void DeleteDirectory(string folderName)
{
    // Base directory where deletions are allowed
    string baseDirectory = "C:\\Sensitive";

    try
    {
        // Validate folder name
        if (string.IsNullOrWhiteSpace(folderName) || folderName.Contains(".."))
        {
            throw new ArgumentException("Invalid folder name.");
        }

        // Construct the full path
        string fullPath = Path.Combine(baseDirectory, folderName);

        // Ensure the path is within the base directory
        if (!fullPath.StartsWith(baseDirectory, StringComparison.OrdinalIgnoreCase))
        {
            throw new UnauthorizedAccessException("Access to this directory is not allowed.");
        }

        // Check if the directory exists
        if (!Directory.Exists(fullPath))
        {
            Console.WriteLine($"Directory does not exist: {fullPath}");
            return;
        }

        // Delete the directory
        Directory.Delete(fullPath, true);
        Console.WriteLine($"Deleted directory: {fullPath}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
