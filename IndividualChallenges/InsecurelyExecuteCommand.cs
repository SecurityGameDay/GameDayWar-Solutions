public void InsecurelyExecuteCommand()
{
    // Insecure: Executes a command to create a sensitive directory
    Process.Start("cmd.exe", "/c mkdir C:\\Sensitive");
    Console.WriteLine("Executed command to create directory C:\\Sensitive.");
}

// SOlve the above vulnerability
public void InsecurelyExecuteCommand()
{
    // Secure: Executes a command to create a sensitive directory
    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.FileName = "cmd.exe";
    startInfo.Arguments = "/c mkdir C:\\Sensitive";
    startInfo.Verb = "runas";
    Process.Start(startInfo);
    Console.WriteLine("Executed command to create directory C:\\Sensitive.");
}
