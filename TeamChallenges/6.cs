using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace XSSAndCSRFWebApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // 1. XSS vulnerability (Injecting user input into HTML response without sanitization)
        [HttpGet("greet")]
        public IActionResult GreetUser(string username)
        {
            return Content($"<h1>Welcome, {username}</h1>"); // XSS vulnerability
        }

        // 2. CSRF vulnerability (No token validation for sensitive operations)
        [HttpPost("updatePassword")]
        public IActionResult UpdatePassword([FromBody] string newPassword)
        {
            // Vulnerable to CSRF as no token is validated
            System.IO.File.WriteAllText("user_password.txt", newPassword); // Sensitive data written to file
            return Ok("Password updated");
        }

        // 3. Logging Sensitive Data (Insecure Logging)
        [HttpPost("logUserAction")]
        public IActionResult LogUserAction([FromBody] string action)
        {
            System.IO.File.AppendAllText("user_actions.log", $"{DateTime.Now}: {action}\n"); // Logs sensitive user actions
            return Ok("Action logged");
        }

        // 4. Insecure File Handling (Writing to a sensitive file location)
        [HttpPost("saveData")]
        public IActionResult SaveData([FromBody] string data)
        {
            System.IO.File.WriteAllText("C:\\SensitiveData\\user_data.txt", data); // Potentially sensitive location
            return Ok("Data saved");
        }

        // 5. Improper Validation (Storing passwords without any hashing or encryption)
        [HttpPost("storePassword")]
        public IActionResult StorePassword([FromBody] string password)
        {
            System.IO.File.WriteAllText("plain_passwords.txt", password); // Storing passwords insecurely
            return Ok("Password stored");
        }
    }
}
