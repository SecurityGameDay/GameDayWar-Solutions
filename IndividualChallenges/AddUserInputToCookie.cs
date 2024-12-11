public void AddUserInputToCookie(string userInput)
{
    // User input added directly to cookies without validation
    Response.Cookies.Add(new HttpCookie("SessionID", userInput)); 
    Console.WriteLine("Cookie added with user input: " + userInput);
}

// use secured ways to store user input in cookies
public void AddUserInputToCookie_Solution(string userInput)
{
    // User input added to cookies after validation
    if (IsValidInput(userInput))
    {
        Response.Cookies.Add(new HttpCookie("SessionID", userInput));
    }
    else
    {
        Console.WriteLine("Invalid user input: " + userInput);
    }
}

public bool IsValidInput(string userInput)
{
    // Validate user input with custom logic that removes any malicious injections or unwanted characters
    return !string.IsNullOrEmpty(userInput);
}