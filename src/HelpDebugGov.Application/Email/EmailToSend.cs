namespace HelpDebugGov.Application.Email;

public class EmailToSend
{
    public required string FromEmail { get; set; }
    public required string FromName { get; set; }
    public required string Subject { get; set; }
    public required string Body { get; set; }
    public required List<(string ToEmail, string ToName)> Recipients { get; set; }
}