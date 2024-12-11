public void EmbedUserInputInScript(string userInput)
{
    // Insecure: Embeds user input directly into a <script> tag
    var html = $"<script>alert('{userInput}')</script>";
    Console.WriteLine("Generated HTML: " + html);
}

// Solution
using System;
using System.Net;
using System.Web;

public void EmbedUserInputInScript(string userInput)
{
    // Secure: Escape user input to prevent XSS
    string safeInput = HttpUtility.HtmlEncode(userInput); // This escapes special HTML characters

    // Safely embedding user input in a script tag
    var html = $"<script>alert('{safeInput}');</script>";
    Console.WriteLine("Generated HTML: " + html);
}
