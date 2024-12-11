public void SetUnlimitedSessionTimeout()
{
    // Disables session expiration
    Session.Timeout = 0; // Vulnerable to session hijacking
    Console.WriteLine("Session timeout set to unlimited.");
}

// Solve the above vulnerability
public void SetUnlimitedSessionTimeout()
{
    // Set a reasonable session timeout
    Session.Timeout = 20; // 20 minutes
    Console.WriteLine("Session timeout set to 20 minutes.");
}