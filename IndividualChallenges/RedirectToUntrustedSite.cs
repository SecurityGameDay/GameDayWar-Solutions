public void RedirectToUntrustedSite(string userInput)
{
    // Insecure: Constructs a URL using user input and redirects without validation
    Response.Redirect("http://malicious.com?token=" + userInput);
    Console.WriteLine("Redirected to: http://malicious.com?token=" + userInput);
}

// Solve the above vulnerability
public void RedirectToUntrustedSite(string userInput)
{
    // Secure: Validates the URL before redirecting
    if (Uri.IsWellFormedUriString(userInput, UriKind.Absolute))
    {
        Response.Redirect(userInput);
        Console.WriteLine("Redirected to: " + userInput);
    }
    else
    {
        Console.WriteLine("Invalid URL: " + userInput);
    }
}