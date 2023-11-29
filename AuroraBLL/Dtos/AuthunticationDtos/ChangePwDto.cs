using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.Authuntication
{
    public class ChangePwDto
    {
        public string Id { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
    }
}
