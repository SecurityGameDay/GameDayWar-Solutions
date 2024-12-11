public void OpenFileStream(string filePath)
{
    // Opens a file using an unvalidated file path
    using (var fs = new FileStream(filePath, FileMode.Open))
    {
        Console.WriteLine("File opened successfully: " + filePath);
    }
}

// Solve the above vulnerability
public void OpenFileStream(string filePath)
{
    // Opens a file using a validated file path
    if (Path.GetExtension(filePath) != ".txt")
    {
        throw new ArgumentException("Invalid file extension");
    }

    using (var fs = new FileStream(filePath, FileMode.Open))
    {
        Console.WriteLine("File opened successfully: " + filePath);
    }
}
