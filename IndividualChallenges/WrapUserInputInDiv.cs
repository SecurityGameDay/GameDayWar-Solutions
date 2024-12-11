public void WrapUserInputInDiv(string userInput)
{
    // Insecure: Wraps user input directly into a <div> without encoding
    var content = "<div>" + userInput + "</div>";
    Console.WriteLine("Generated content: " + content);
}

// Solve the above vulnerability
public void WrapUserInputInDiv(string userInput)
{
    // Encode user input before wrapping it in a <div>
    var content = "<div>" + HttpUtility.HtmlEncode(userInput) + "</div>";
    Console.WriteLine("Generated content: " + content);
}