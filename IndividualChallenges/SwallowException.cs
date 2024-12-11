public void SwallowException()
{
    try
    {
        DoSomething(); // This method might throw an exception
    }
    catch
    {
        // Silently swallow the exception
    }
}

private void DoSomething()
{
    throw new InvalidOperationException("An error occurred in DoSomething.");
}

// solve the above vulnerability
public void SwallowException()
{
    try
    {
        DoSomething(); // This method might throw an exception
    }
    catch (Exception ex)
    {
        string sanitizedExceptionMessage = RemovePII(ex.message);
        Console.WriteLine($"An error occurred: {sanitizedExceptionMessage}");
    }
}
