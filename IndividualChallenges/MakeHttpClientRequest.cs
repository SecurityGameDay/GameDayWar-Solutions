public void MakeHttpClientRequest(string host)
{
    var client = new HttpClient
    {
        BaseAddress = new Uri("http://" + host) // Insecure: Uses HTTP instead of HTTPS
    };
    var response = client.GetAsync("/api/data").Result;
    Console.WriteLine("Response status: " + response.StatusCode);
}

// Solve the above vulnerability
public void MakeHttpClientRequest(string host)
{
    var client = new HttpClient
    {
        BaseAddress = new Uri("https://" + host) // Secure: Uses HTTPS instead of HTTP
    };
    var response = client.GetAsync("/api/data").Result;
    Console.WriteLine("Response status: " + response.StatusCode);
}