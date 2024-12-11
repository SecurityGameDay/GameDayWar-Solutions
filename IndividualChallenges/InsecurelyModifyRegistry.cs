public void InsecurelyModifyRegistry()
{
    // Insecure: Sets a registry key value that enables administrative access
    Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\App", "AdminAccess", "true");
    Console.WriteLine("Set registry key AdminAccess to true.");
}

// Solve the above vulnerability
public void InsecurelyModifyRegistry()
{
    // Secure: Sets a registry key value with secure permissions
    RegistryKey key = Registry.LocalMachine.CreateSubKey("Software\\App");
    key.SetValue("AdminAccess", "true", RegistryValueKind.String);
    Console.WriteLine("Set registry key AdminAccess to true.");
}
