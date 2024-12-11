public void RunPowerShellScript(string userInput)
{
    string command = $"powershell.exe {userInput}";

    Process process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            Arguments = userInput,
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
public void RunPowerShellScript(string userInput)
{
    // Validate the user input to prevent command injection
    if (!IsValidPowerShellCommand(userInput))
    {
        Console.WriteLine("Invalid PowerShell command.");
        return;
    }

    string command = $"powershell.exe {userInput}";

    Process process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            Arguments = userInput,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        }
    };
    process.Start();
    string output = process.StandardOutput.ReadToEnd();
    Console.WriteLine(output);
}
