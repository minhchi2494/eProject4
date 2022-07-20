using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.MailService
{
    public interface IMailService
    {
        Task sendPasswordViaEmail(MailRequest request);
    }
}
