using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace InsecureWebAPIWithXSSAndFileOperations
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // 1. XSS Vulnerability (Injecting user input into HTML without escaping)
        [HttpGet("greet")]
        public IActionResult GreetUser(string username)
        {
            return Content($"<h1>Welcome, {username}</h1>"); // XSS vulnerability
        }

        // 2. Insecure File Handling (Storing data in sensitive locations)
        [HttpPost("storeData")]
        public IActionResult StoreData([FromBody] string data)
        {
            File.WriteAllText("C:\\SensitiveData\\user_info.txt", data); // Writing data to a sensitive location
            return Ok("Data stored");
        }

        // 3. Weak Cryptography (Storing passwords using MD5)
        [HttpPost("storePassword")]
        public IActionResult StorePassword([FromBody] string password)
        {
            string hashedPassword = InsecurePasswordManager.HashPassword(password); // MD5 hash
            File.WriteAllText("passwords.txt", hashedPassword); // Insecure password storage
            return Ok("Password stored");
        }

        // 4. CSRF Vulnerability (No token validation for sensitive operations)
        [HttpPost("updateEmail")]
        public IActionResult UpdateEmail([FromBody] string email)
        {
            File.WriteAllText("user_email.txt", email); // Vulnerable to CSRF
            return Ok("Email updated");
        }

        // 5. Logging Sensitive Data
        [HttpPost("logUserAction")]
        public IActionResult LogUserAction([FromBody] string action)
        {
            File.AppendAllText("user_actions.log", $"{DateTime.Now}: {action}\n"); // Logging sensitive actions
            return Ok("Action logged");
        }
    }
}
