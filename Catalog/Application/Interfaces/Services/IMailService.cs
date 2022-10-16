using Catalog.Application.Requests.Mail;
using System.Threading.Tasks;

namespace Catalog.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}