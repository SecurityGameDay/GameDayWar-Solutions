public void DownloadFile(string url)
{
    using (var client = new WebClient())
    {
        client.DownloadFile("http://example.com/file.txt", "file.txt"); // Insecure: Uses HTTP and hardcoded URL
    }
    Console.WriteLine("File downloaded from: " + url);
}

// Solution
using System;
using System.Net;

public void DownloadFile(string url)
{
    // Validate the URL to ensure it's not empty and uses HTTPS
    if (string.IsNullOrEmpty(url) || !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Invalid or insecure URL. Only HTTPS URLs are allowed.");
        return;
    }

    try
    {
        // Extract file name from URL (or provide a default name)
        string fileName = "downloaded_file.txt"; // Default file name
        Uri fileUri = new Uri(url);
        fileName = fileUri.Segments[fileUri.Segments.Length - 1]; // Get the file name from the URL

        // Download the file securely using WebClient
        using (var client = new WebClient())
        {
            client.DownloadFile(url, fileName);
            Console.WriteLine($"File downloaded from: {url}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error downloading file: {ex.Message}");
    }
}
