using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.MailService
{
    public interface IMailService
    {
        Task sendPinCodeToEmail(MailRequest request);
    }
}
