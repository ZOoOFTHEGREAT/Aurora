using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Services.Email
{
    public class MailSettings
    {
        [RegularExpression(@"^[a-zA-Z0-9]+@.*\.com")]
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}
