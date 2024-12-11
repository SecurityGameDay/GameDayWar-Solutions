public void UseStaticTokenInCookie()
{
    // Creates a cookie with a hardcoded static token
    HttpCookie authCookie = new HttpCookie("auth", "static-token"); 
    Response.Cookies.Add(authCookie);
    Console.WriteLine("Static authentication token added to cookies.");
}

// Solve the above vulnerability
public void UseStaticTokenInCookie()
{
    // Generate a random token and store it in a cookie
    string token = GenerateRandomToken();
    HttpCookie authCookie = new HttpCookie("auth", token); 
    Response.Cookies.Add(authCookie);
    Console.WriteLine("Random authentication token added to cookies.");
}