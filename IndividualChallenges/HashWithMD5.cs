public void HashWithMD5(byte[] data)
{
    var md5 = MD5.Create(); // Insecure hashing algorithm
    var hash = md5.ComputeHash(data);
    Console.WriteLine($"MD5 Hash: {Convert.ToHexString(hash)}");
}

// solve the above vulnerability
public void HashWithMD5(byte[] data)
{
    var sha256 = SHA256.Create(); // Use a more secure hashing algorithm
    // use salt to prevent rainbow table attacks
    var salt = new byte[] { 0x53, 0x61, 0x6C, 0x74 }; // Salt value
    data = data.Concat(salt).ToArray(); // Append salt to data
    var hash = sha256.ComputeHash(data);

    Console.WriteLine($"SHA256 Hash: {Convert.ToHexString(hash)}");
}