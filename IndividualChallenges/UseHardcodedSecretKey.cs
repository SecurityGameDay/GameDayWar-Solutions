public void UseHardcodedSecretKey(string data)
{
    string secretKey = "hardcoded_secret"; // Insecure practice
    var hashedKey = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(secretKey));

    Console.WriteLine($"Key Derived from Hardcoded Secret: {Convert.ToHexString(hashedKey)}");
}

// Solve the above vulnerability
public void UseSecureSecretKey(string data)
{
    string secretKey = GetSecretKeyFromSecureSource();
    var hashedKey = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(secretKey));

    Console.WriteLine($"Key Derived from Secure Secret: {Convert.ToHexString(hashedKey)}");
}