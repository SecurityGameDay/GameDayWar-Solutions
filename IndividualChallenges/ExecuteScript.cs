public void ExecuteScript(string userInput)
{
    // Hypothetical scripting engine
    string script = $"eval({userInput})";
    dynamic engine = Activator.CreateInstance(Type.GetType("HypotheticalScriptingEngine"));
    engine.Execute(script);
}

// Solution 1
public void ExecuteScript(string userInput)
{
    // Validate and restrict user input
    if (!IsValidInput(userInput))
    {
        throw new InvalidOperationException("Invalid input detected.");
    }

    // Hypothetical secure scripting engine that does not allow dangerous operations
    dynamic engine = Activator.CreateInstance(Type.GetType("HypotheticalSecureScriptingEngine"));
    engine.Execute(userInput);
}

private bool IsValidInput(string input)
{
    // Example validation: restrict to alphanumeric and specific symbols
    return !string.IsNullOrEmpty(input) && System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z0-9\s\+\-\*\/\(\)]*$");
}

// Solution 2
public void ExecuteWhitelistedScript(string userInput)
{
    var allowedCommands = new[] { "add", "subtract", "multiply", "divide" };

    // Parse and validate the input command
    string[] parts = userInput.Split(' ');
    if (parts.Length != 3 || !allowedCommands.Contains(parts[0]))
    {
        throw new InvalidOperationException("Invalid script command.");
    }

    int operand1, operand2;
    if (!int.TryParse(parts[1], out operand1) || !int.TryParse(parts[2], out operand2))
    {
        throw new InvalidOperationException("Invalid operands.");
    }

    // Perform the allowed operation
    int result = parts[0] switch
    {
        "add" => operand1 + operand2,
        "subtract" => operand1 - operand2,
        "multiply" => operand1 * operand2,
        "divide" => operand2 != 0 ? operand1 / operand2 : throw new InvalidOperationException("Division by zero."),
        _ => throw new InvalidOperationException("Unknown operation.")
    };

    Console.WriteLine($"Result: {result}");
}
