public void WriteExceptionToFile(Exception ex)
{
    try
    {
        DoSomethingRisky();
    }
    catch (Exception caughtEx)
    {
        File.WriteAllText("error.log", caughtEx.ToString()); // Dumps exception to a file
    }
}

// solve the above vulnerability
using System;
using System.IO;

public void WriteExceptionToFile(Exception ex)
{
    try
    {
        DoSomethingRisky();
    }
    catch (Exception caughtEx)
    {
        // Restrict log content to high-level information
        string logMessage = $"Error occurred at {DateTime.UtcNow}: {caughtEx.Message}";

        // Define a secure location for log files
        string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "error.log");

        // Ensure the directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

        // Write the log to a file
        File.AppendAllText(logFilePath, logMessage + Environment.NewLine);

        // Optionally log to a secure logging framework
        Console.WriteLine("An error occurred and has been logged.");
    }
}

private void DoSomethingRisky()
{
    // Simulate risky behavior
    throw new InvalidOperationException("Simulated exception.");
}

