public void LogExceptionDirectly()
{
    try
    {
        int result = 10 / 0; // Force a divide-by-zero exception
    }
    catch (Exception e)
    {
        Console.WriteLine(e); // Directly printing exception details
    }
}

// Solve the above vulnerability
public void LogExceptionDirectly()
{
    try
    {
        int result = 10 / 0; // Force a divide-by-zero exception
    }
    catch (Exception e)
    {
        // Log the exception details to a file
        // make sure PII data is not logged
        
        LogExceptionToFile(e);
    }
}
