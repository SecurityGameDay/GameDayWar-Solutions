public void LogUserInputToConsole(string userInput)
{
    // Insecure: Embeds user input directly into HTML-like formatting
    Console.WriteLine($"<b>{userInput}</b>");
    Console.WriteLine("Logged user input in bold HTML format.");
}

// Solve the above vulnerability
public void LogUserInputToConsole(string userInput)
{
    // Secure: Escapes user input to prevent HTML injection
    Console.WriteLine(WebUtility.HtmlEncode(userInput));
    Console.WriteLine("Logged user input with HTML encoding.");
}