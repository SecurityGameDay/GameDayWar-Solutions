public void ReadFileFromFixedDirectory(string filename)
{
    // Opens a file based on user input without validating the filename
    using (var stream = File.OpenRead("C:\\uploads\\" + filename))
    {
        Console.WriteLine("Opened file: " + filename);
    }
}

// Solve the above vulnerability
public void ReadFileFromFixedDirectory(string filename)
{
    // Opens a file based on user input without validating the filename
    if (Path.GetExtension(filename) != ".txt")
    {
        throw new ArgumentException("Invalid file extension");
    }

    using (var stream = File.OpenRead("C:\\uploads\\" + filename))
    {
        Console.WriteLine("Opened file: " + filename);
    }
}