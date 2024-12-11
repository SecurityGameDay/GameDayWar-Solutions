public void UseHardcodedApiKey()
{
    string apiKey = "abcdef12345"; // Insecure: Hardcoded API key
    Console.WriteLine("Using API key: " + apiKey);

    // Simulate API usage
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    var response = client.GetAsync("https://api.example.com/data").Result;
    Console.WriteLine("Response: " + response.StatusCode);
}

// Solve the above vulnerability
public void UseHardcodedApiKey()
{
    // Fetch the API key from a secure source
    string apiKey = GetApiKeyFromSecureSource();
    Console.WriteLine("Using API key: " + apiKey);

    // Simulate API usage
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {decryt(apiKey)}");
    var response = client.GetAsync("https://api.example.com/data").Result;
    Console.WriteLine("Response: " + response.StatusCode);
}
