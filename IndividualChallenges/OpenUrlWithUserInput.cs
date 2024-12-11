public void OpenUrlWithUserInput(string userInput)
{
    // Insecure: Launches a URL constructed with raw user input
    Process.Start("http://example.com/resetpassword?email=" + userInput);
    Console.WriteLine("Opened URL: http://example.com/resetpassword?email=" + userInput);
}

// Solve the above vulnerability
using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Web;

public void OpenUrlWithUserInput(string userInput)
{
    try
    {
        // Validate the user input (e.g., check if it's a valid email address)
        if (!IsValidEmail(userInput))
        {
            throw new ArgumentException("Invalid email address.");
        }

        // Encode the user input to prevent URL manipulation
        string encodedEmail = HttpUtility.UrlEncode(userInput);

        // Construct the secure URL
        string url = $"https://example.com/resetpassword?email={encodedEmail}";

        // Open the URL in the default browser
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true // Ensures safe URL opening in a browser
        });

        Console.WriteLine("Opened URL: " + url);
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }
}

private bool IsValidEmail(string email)
{
    try
    {
        var mailAddress = new MailAddress(email);
        return true;
    }
    catch
    {
        return false;
    }
}
