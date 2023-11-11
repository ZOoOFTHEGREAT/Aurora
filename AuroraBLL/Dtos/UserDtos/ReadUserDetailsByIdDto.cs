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
        public virtual ICollection<ReadOrdersDto> Orders { get; set; } = new List<ReadOrdersDto>();
        public virtual ICollection<ReadUserPaymentDetailDto> UserPayments { get; set; } = new List<ReadUserPaymentDetailDto>();
        public virtual ICollection<ReadUserAddressDetailDto> UserAddresses { get; set; } = new List<ReadUserAddressDetailDto>();
    }
}
