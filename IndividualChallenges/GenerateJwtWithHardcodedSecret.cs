public void GenerateJwtWithHardcodedSecret(string username)
{
    const string jwtSecret = "static_secret"; // Insecure: Hardcoded secret
    Console.WriteLine("Generating JWT with hardcoded secret.");

    // Simulate JWT creation
    var payload = $"{{ \"username\": \"{username}\" }}";
    var signature = Convert.ToBase64String(Encoding.UTF8.GetBytes(jwtSecret));
    var jwt = $"{Convert.ToBase64String(Encoding.UTF8.GetBytes(payload))}.{signature}";

    Console.WriteLine("Generated JWT: " + jwt);
}


// Solution

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

public void GenerateJwt(string username)
{
    // Fetch the secret securely (e.g., from environment variables)
    string jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
    if (string.IsNullOrEmpty(jwtSecret))
    {
        throw new InvalidOperationException("JWT secret not configured.");
    }

    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
    var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

    // Create the JWT payload
    var claims = new[] { new Claim(ClaimTypes.Name, username) };
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddHours(1),
        SigningCredentials = credentials
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);
    string jwt = tokenHandler.WriteToken(token);

    Console.WriteLine("Generated JWT: " + jwt);
}
