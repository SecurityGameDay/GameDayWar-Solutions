using System;
using System.IO;

namespace InsecureFileOperations
{
    public class FileHandler
    {
        // 1. Storing sensitive data without encryption
        public static void StoreSensitiveData(string data)
        {
            File.WriteAllText("sensitiveData.txt", data); // Data stored in plaintext
        }

        // 2. Directory Traversal vulnerability (Insecure file path usage)
        public static void DeleteFile(string userInput)
        {
            string filePath = "C:\\Files\\" + userInput; // Vulnerable to directory traversal
            File.Delete(filePath); // Delete operation on insecure file path
        }

        // 3. Insecure Logging (Sensitive data in logs)
        public static void LogData(string data)
        {
            File.AppendAllText("log.txt", $"{DateTime.Now}: {data}\n"); // Logs sensitive data without encryption
        }

        // 4. Insecure File Permissions (No checks on who can access the file)
        public static void ChangeFilePermissions(string filePath)
        {
            File.SetAttributes(filePath, FileAttributes.Normal); // Insecure file attribute changes
        }

        // 5. Data Integrity (File modification without integrity checks)
        public static void ModifyFileData(string filePath, string newData)
        {
            File.WriteAllText(filePath, newData); // Modifying file without any integrity checks
        }
    }
}
