public void StoreTokenInSession(string token)
{
    // Stores token in session without encryption
    Session["AuthToken"] = token;
    Console.WriteLine("Token stored in session.");
}

// Solve the above vulnerability
public void StoreTokenInSession(string token)
{
    // Encrypt the token before storing it in session
    Session["AuthToken"] = EncryptToken(token);
    Console.WriteLine("Token stored in session.");
}