public void AuthenticateWithHardcodedPassword()
{
    string password = "P@ssword!"; // Insecure: Hardcoded password
    Console.WriteLine("Authenticating with hardcoded password.");

    // Simulate authentication
    if (password == "P@ssword!")
    {
        Console.WriteLine("Authentication successful.");
    }
    else
    {
        Console.WriteLine("Authentication failed.");
    }
}


// Soltuion

using System;
using System.Security.Cryptography;
using System.Text;

public class SecureAuthentication
{
    // Simulated secure storage for a hashed password (to be replaced with a database in real applications)
    private static readonly string storedPasswordHash = HashPassword("P@ssword!");

    public void Authenticate(string inputPassword)
    {
        Console.WriteLine("Authenticating with user-provided password.");

        // Validate the input password
        if (VerifyPassword(inputPassword, storedPasswordHash))
        {
            Console.WriteLine("Authentication successful.");
        }
        else
        {
            Console.WriteLine("Authentication failed.");
        }
    }

    private static string HashPassword(string password)
    {
        // Use a cryptographic hash function (SHA-256 in this example)
        using (var sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }

    private static bool VerifyPassword(string inputPassword, string storedHash)
    {
        // Hash the input password and compare it to the stored hash
        string inputHash = HashPassword(inputPassword);
        return inputHash == storedHash;
    }
}

// Example usage:
// var auth = new SecureAuthentication();
// auth.Authenticate("P@ssword!"); // Should succeed
// auth.Authenticate("WrongPassword"); // Should fail
