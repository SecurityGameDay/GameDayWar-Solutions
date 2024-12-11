public void AuthenticateUser(string password)
{
    if (password == "admin123") // Hardcoded password
    {
        GrantAccess(); // Insecurely grants access
    }
    else
    {
        Console.WriteLine("Access Denied.");
    }
}

private void GrantAccess()
{
    Console.WriteLine("Access Granted!");
}

// solve the above vulnerability
using System;
using System.Security.Cryptography;
using System.Text;

public class SecureAuthentication
{
    // Simulated database-stored hashed password
    private static readonly string storedPasswordHash = HashPassword("admin123");

    public void AuthenticateUser(string password)
    {
        // Hash the input password and compare with stored hash
        if (VerifyPassword(password, storedPasswordHash))
        {
            GrantAccess(); // Securely grants access
        }
        else
        {
            Console.WriteLine("Access Denied.");
        }
    }

    private void GrantAccess()
    {
        Console.WriteLine("Access Granted!");
    }

    private static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }

    private static bool VerifyPassword(string inputPassword, string storedHash)
    {
        string inputHash = HashPassword(inputPassword);
        return inputHash == storedHash;
    }
}
