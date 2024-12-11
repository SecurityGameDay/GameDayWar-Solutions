public void RunCommand(string userInput)
{
    Process process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "/c " + userInput,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        }
    };
    process.Start();
    string output = process.StandardOutput.ReadToEnd();
    Console.WriteLine(output);
}

// solve the above vulnerability
public void RunCommand(string userInput)
{
    // Validate the user input to prevent command injection
    if (!IsValidCommand(userInput))
    {
        Console.WriteLine("Invalid command.");
        return;
    }

    Process process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "/c " + userInput,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        }
    };
    process.Start();
    string output = process.StandardOutput.ReadToEnd();
    Console.WriteLine(output);
}
