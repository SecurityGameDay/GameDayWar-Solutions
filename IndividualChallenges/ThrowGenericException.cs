public void ThrowGenericException(Exception ex)
{
    try
    {
        DoSomethingRisky();
    }
    catch (Exception innerEx)
    {
        throw new Exception("Error: " + innerEx.Message); // Concatenating exception details
    }
}

private void DoSomethingRisky()
{
    throw new ArgumentNullException("Parameter cannot be null.");
}

// Solve the above vulnerability
public void ThrowGenericException(Exception ex)
{
    try
    {
        DoSomethingRisky();
    }
    catch (Exception innerEx)
    {
        var sanitizedException = RemovePII(innerEx);
        throw new Exception("An error occurred: " + sanitizedException.Message, sanitizedException); // Preserve the original exception
    }
}