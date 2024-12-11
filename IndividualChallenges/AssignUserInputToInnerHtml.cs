public void AssignUserInputToInnerHtml(string userInput)
{
    // Insecure: Assigns raw user input to InnerHtml
    var res = new System.Web.UI.HtmlControls.HtmlGenericControl();
    res.InnerHtml = userInput; // Vulnerable to XSS
    Console.WriteLine("Set InnerHtml to: " + userInput);
}

// Use secured ways to assign user input to InnerHtml
using System;
using System.Web;

public void AssignUserInputToInnerHtml_Solution1(string userInput)
{
    // Secure: Encodes user input to prevent XSS
    var res = new System.Web.UI.HtmlControls.HtmlGenericControl();
    res.InnerHtml = HttpUtility.HtmlEncode(userInput); // Encodes user input
    Console.WriteLine("Set InnerHtml to: " + HttpUtility.HtmlEncode(userInput));
}

using Ganss.XSS;

public void AssignUserInputToInnerHtml_solution2(string userInput)
{
    // Sanitize user input to allow only safe HTML
    var sanitizer = new HtmlSanitizer();
    string sanitizedInput = sanitizer.Sanitize(userInput);
    
    var res = new System.Web.UI.HtmlControls.HtmlGenericControl();
    res.InnerHtml = sanitizedInput; // Assign sanitized HTML
    Console.WriteLine("Set InnerHtml to: " + sanitizedInput);
}
