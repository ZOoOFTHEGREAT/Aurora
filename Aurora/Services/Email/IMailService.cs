namespace AuroraAPI.Services.Email
{
    public interface IMailService
    {
        public Task SendEmailAsync(string emailto, string subject, string body);
    }
}
