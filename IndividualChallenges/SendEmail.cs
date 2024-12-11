public void SendEmail(string recipient, string message)
{
    var smtp = new SmtpClient("smtp.example.com", 25) // Insecure: No encryption
    {
        Credentials = new NetworkCredential("user@example.com", "password"),
        EnableSsl = false // Explicitly disabled secure communication
    };
    smtp.Send("user@example.com", recipient, "Subject", message);
    Console.WriteLine("Email sent to: " + recipient);
}

// solve the above vulnerability
public void SendEmail(string recipient, string message)
{
    var smtp = new SmtpClient("smtp.example.com", 587) // Secure: Uses port 587 for encrypted communication
    {
        Credentials = new NetworkCredential("user@example.com", "password"),
        EnableSsl = true // Enables secure communication
    };
    smtp.Send("user@example.com", recipient, "Subject", message);
    Console.WriteLine("Email sent to: " + recipient);
}
