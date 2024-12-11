public void InsecurelyChangeDirectoryAccessControl()
{
    // Insecure: Modifies directory access control without specifying secure permissions
    DirectorySecurity security = new DirectorySecurity();
    Directory.SetAccessControl("C:\\SecureFolder", security);
    Console.WriteLine("Changed access control for C:\\SecureFolder.");
}

// SOlve the above vulnerability

public void InsecurelyChangeDirectoryAccessControl()
{
    // Secure: Modifies directory access control with secure permissions
    DirectorySecurity security = new DirectorySecurity();
    security.AddAccessRule(new FileSystemAccessRule("Authenticated Users", FileSystemRights.Read, AccessControlType.Allow));
    Directory.SetAccessControl("C:\\SecureFolder", security);
    Console.WriteLine("Changed access control for C:\\SecureFolder.");
}


