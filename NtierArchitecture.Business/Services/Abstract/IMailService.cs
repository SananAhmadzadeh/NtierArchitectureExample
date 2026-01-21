namespace NtierArchitecture.Business.Services.Abstract
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
