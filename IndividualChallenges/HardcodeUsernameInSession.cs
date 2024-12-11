public void HardcodeUsernameInSession()
{
    // Hardcodes the username "admin" into the session
    HttpContext.Current.Session["username"] = "admin"; 
    Console.WriteLine("Username 'admin' hardcoded in session.");
}

// solve the above vulnerability
public void HardcodeUsernameInSession()
{
    // Fetch the username from a secure source
    string username = GetUsernameFromSecureSource();
    HttpContext.Current.Session["username"] = username;
    Console.WriteLine($"Username '{username}' stored in session.");
}

