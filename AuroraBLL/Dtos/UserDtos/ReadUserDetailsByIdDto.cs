using AuroraBLL.Dtos.OrderDtos;
using AuroraBLL.Dtos.UserAddressDtos;
using AuroraBLL.Dtos.UserPaymentDtos;
using AuroraDAL;


namespace AuroraBLL.Dtos.UserDtos
{
    public class ReadUserDetailsByIdDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Fname { get; set; } = string.Empty;
        public string Lname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int ZipCode { get; set; }
        public Cart Cart { get; set; } = null!;
        public virtual ICollection<ReadOrderDto> OrderDtos { get; set; } = new List<ReadOrderDto>();
        public virtual ICollection<ReadUserPaymentDto> UserPaymentDtos { get; set; } = new List<ReadUserPaymentDto>();
        public virtual ICollection<ReadUserAddressDto> UserAddressesDtos { get; set; } = new List<ReadUserAddressDto>();
    }
}
