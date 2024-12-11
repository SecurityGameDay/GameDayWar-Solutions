public void InsecureModifyFileAttributes()
{
    // Insecure: Removes any special attributes from a secure file
    File.SetAttributes("C:\\SecureFile.txt", FileAttributes.Normal);
    Console.WriteLine("File attributes set to normal.");
}

// Solve the above vulnerability
public void InsecureModifyFileAttributes()
{
    // Secure: Removes only the read-only attribute from a secure file
    FileAttributes attributes = File.GetAttributes("C:\\SecureFile.txt");
    attributes &= ~FileAttributes.ReadOnly;
    File.SetAttributes("C:\\SecureFile.txt", attributes);
    Console.WriteLine("Read-only attribute removed from file.");
}
