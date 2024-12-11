using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.Http;

namespace VulnerableWebAPI.Controllers
{
    [RoutePrefix("api/insecure")]
    public class InsecureController : ApiController
    {
        // Hardcoded Database Connection String (Vulnerability #3)
        private readonly string connectionString = "Server=myServer;Database=SensitiveDB;User Id=admin;Password=admin123;";

        // Insecure endpoint to fetch user data
        [HttpGet]
        [Route("getUserData")]
        public IHttpActionResult GetUserData(string userId)
        {
            try
            {
                // SQL Injection Vulnerability (#1)
                string query = $"SELECT * FROM Users WHERE UserId = '{userId}'";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return Ok(new
                        {
                            UserId = reader["UserId"],
                            Name = reader["Name"],
                            Email = reader["Email"]
                        });
                    }
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                // Improper Error Handling (#4)
                return InternalServerError(ex);
            }
        }

        // Insecure endpoint to access files
        [HttpGet]
        [Route("getFile")]
        public IHttpActionResult GetFile(string fileName)
        {
            try
            {
                // Insecure Direct Object Reference (#2)
                string filePath = "C:\\SecureFiles\\" + fileName;

                // Unrestricted File Access (#5)
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    return Ok(new { FileName = fileName, Content = content });
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Insecure debug endpoint
        [HttpGet]
        [Route("debug")]
        public IHttpActionResult Debug()
        {
            // Insecure Configuration (#6)
            return Ok(new
            {
                Environment = "Debug",
                MachineName = Environment.MachineName,
                Uptime = Environment.TickCount
            });
        }
    }
}
