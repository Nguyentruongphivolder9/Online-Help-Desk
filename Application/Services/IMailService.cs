using Application.DTOs;

namespace Application.Services
{
    public interface IMailService
    {
        Task SendMailAsync(MailRequest mailRequest);
    }
}
