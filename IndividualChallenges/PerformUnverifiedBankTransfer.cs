public void PerformUnverifiedBankTransfer()
{
    // Insecure: Hardcoded and unsanitized request to a sensitive URL
    WebClient client = new WebClient();
    string response = client.DownloadString("http://bank.com/transfer?amount=100");
    Console.WriteLine("Transfer initiated with response: " + response);
}

// solve the above vulnerability
public void PerformUnverifiedBankTransfer()
{
    // Secure: Uses HTTPS and verifies the server certificate
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    using (WebClient client = new WebClient())
    {
        client.BaseAddress = "https://bank.com";
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["amount"] = "100";
        string url = "/transfer?" + query.ToString();
        string response = client.DownloadString(url);
        Console.WriteLine("Transfer initiated with response: " + response);
    }
}