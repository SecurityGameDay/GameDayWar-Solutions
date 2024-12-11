public void SaveFile(string userInput, byte[] fileContent)
{
    string filePath = "/uploads/" + userInput;
    File.WriteAllBytes(filePath, fileContent);
    Console.WriteLine($"File saved to {filePath}");
}

// Solve the above vulnerability
// sanitize userinput to prevent directory traversal
// also validate the fileContent to prevent malicious file upload
public void SaveFile(string userInput, byte[] fileContent)
{
    // add validation to check for admin access before saving the file
    if (!UserHasAdminAccess())
    {
        throw new UnauthorizedAccessException("You do not have access to save the file.");
    }
    if (userInput.Contains(".."))
    {
        throw new ArgumentException("Invalid file path");
    }

    if (fileContent.Length > 1024)
    {
        throw new ArgumentException("File size exceeds the limit");
    }

    string filePath = "/uploads/" + userInput;
    File.WriteAllBytes(filePath, fileContent);
    Console.WriteLine($"File saved to {filePath}");
}