namespace HelpDebugGov.Application.Email;

using System.Net;
using System.Threading.Tasks;

public interface IEmailManager
{
    Task<HttpStatusCode> SendEmail(EmailToSend emailToSend);
}