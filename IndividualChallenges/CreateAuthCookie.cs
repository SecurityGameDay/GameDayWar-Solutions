public void CreateAuthCookie(string userInput)
{
    // Creating a new cookie with the user's input
    HttpCookie authCookie = new HttpCookie("auth", userInput)
    {
        HttpOnly = true,
        Secure = true
    };
    HttpContext.Current.Response.Cookies.Add(authCookie);
    Console.WriteLine("Cookie has been set.");
}

// Solution

using System;
using System.Web;
using System.Security.Cryptography;

public void CreateAuthCookie(string userInput)
{
    // Validate and sanitize user input
    if (string.IsNullOrWhiteSpace(userInput))
    {
        Console.WriteLine("Invalid input for cookie creation.");
        return;
    }

    // Generate a secure value for the cookie (e.g., a hashed or tokenized version of the input)
    string secureValue = GenerateSecureToken(userInput);

    // Creating a secure cookie
    HttpCookie authCookie = new HttpCookie("auth", secureValue)
    {
        HttpOnly = true, // Prevent JavaScript access (mitigates XSS)
        Secure = HttpContext.Current.Request.IsSecureConnection, // Ensures the cookie is sent over HTTPS only
        SameSite = SameSiteMode.Strict // Prevents CSRF by restricting cross-site requests
    };

    // Add the cookie to the response
    HttpContext.Current.Response.Cookies.Add(authCookie);
    Console.WriteLine("Secure cookie has been set.");
}

// Example method to generate a secure token (hash)
private string GenerateSecureToken(string input)
{
    using (var sha256 = SHA256.Create())
    {
        byte[] hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(hashBytes);
    }
}

