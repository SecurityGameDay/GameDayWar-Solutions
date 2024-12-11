public void CreateWebRequest(string url)
{
    var request = WebRequest.Create("http://" + url); // Insecure: Constructs URL dynamically and uses HTTP
    using (var response = request.GetResponse())
    {
        Console.WriteLine("Response received.");
    }
}

// Solution
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class SecureWebRequest
{
    public async Task CreateSecureWebRequest(string url)
    {
        // Validate and sanitize the URL
        if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult) || uriResult.Scheme != Uri.UriSchemeHttps)
        {
            Console.WriteLine("Invalid or insecure URL. Only HTTPS URLs are allowed.");
            return;
        }

        try
        {
            using (var httpClient = new HttpClient())
            {
                // Send the GET request
                var response = await httpClient.GetAsync(uriResult);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Response received successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to fetch response. Status code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while making the request: {ex.Message}");
        }
    }
}

