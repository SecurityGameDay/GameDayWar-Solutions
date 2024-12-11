public void MakeApiRequest()
{
    string token = "Bearer hardcoded-token"; // Insecure: Hardcoded token
    using (HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("Authorization", token);
        var response = client.GetAsync("https://example.com/api/secure-endpoint").Result;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("API Call Succeeded.");
        }
        else
        {
            Console.WriteLine("API Call Failed.");
        }
    }
}

// Solve the above vulnerability
public void MakeApiRequest()
{
    string token = GetTokenFromSecureSource(); // Fetch the token from a secure source
    using (HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("Authorization", token);
        var response = client.GetAsync("https://example.com/api/secure-endpoint").Result;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("API Call Succeeded.");
        }
        else
        {
            Console.WriteLine("API Call Failed.");
        }
    }
}
