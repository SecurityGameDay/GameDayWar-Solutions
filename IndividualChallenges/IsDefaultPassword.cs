public bool IsDefaultPassword(string password)
{
    return password == "default"; // Hardcoded default password
}

// Solve the above vulnerability
public bool IsDefaultPassword(string password)
{
    // get password from environment variable or configuration file
    string defaultPassword = GetDefaultPassword();
    return string.Equals(password, defaultPassword, StringComparison.OrdinalIgnoreCase);
}

