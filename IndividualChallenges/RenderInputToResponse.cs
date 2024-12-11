public void RenderInputToResponse(string userInput)
{
    // Insecure: Writes raw user input directly into the response
    Response.Write("<p>" + userInput + "</p>");
    Console.WriteLine("Rendered to response: <p>" + userInput + "</p>");
}

// Solve the above vulnerability
public void RenderInputToResponse(string userInput)
{
    // Secure: Escapes user input to prevent HTML injection
    Response.Write("<p>" + WebUtility.HtmlEncode(userInput) + "</p>");
    Console.WriteLine("Rendered to response: <p>" + WebUtility.HtmlEncode(userInput) + "</p>");
}