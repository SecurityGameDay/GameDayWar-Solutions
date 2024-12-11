public void CreateTcpClient(string host)
{
    var tcpClient = new TcpClient(host, 80); // Insecure: No encryption and uses HTTP
    Console.WriteLine("TCP client connected to: " + host);
}


// Solution

using System;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

public void CreateSecureTcpClient(string host)
{
    try
    {
        using (var tcpClient = new TcpClient(host, 443)) // Connect using HTTPS port
        {
            Console.WriteLine("TCP client connected to: " + host);

            // Establish an SSL stream
            using (var sslStream = new SslStream(
                tcpClient.GetStream(),
                false,
                new RemoteCertificateValidationCallback(ValidateServerCertificate),
                null))
            {
                // Authenticate the server and optionally the client
                sslStream.AuthenticateAsClient(host);

                if (sslStream.IsEncrypted && sslStream.IsAuthenticated)
                {
                    Console.WriteLine("Secure connection established.");
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Failed to establish secure connection: " + ex.Message);
    }
}

// Server certificate validation callback
private static bool ValidateServerCertificate(
    object sender,
    X509Certificate certificate,
    X509Chain chain,
    SslPolicyErrors sslPolicyErrors)
{
    if (sslPolicyErrors == SslPolicyErrors.None)
    {
        return true; // Certificate is valid
    }

    Console.WriteLine("Certificate error: " + sslPolicyErrors);
    return false; // Certificate is invalid
}
