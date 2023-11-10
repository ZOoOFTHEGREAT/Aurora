using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos;

public class AddCartDto
{
    public DateTime CreatedDate { get; set; }
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = null!;
}
