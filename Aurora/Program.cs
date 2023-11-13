using AuroraBLL;
using AuroraBLL.Managers.CategoryManager;
using AuroraBLL.Managers.PaymentDetailManager;
using AuroraBLL.Managers.ShippingCompanyManager;
using AuroraBLL.Managers.UserAddressManager;
using AuroraBLL.Managers.UserManager;
using AuroraBLL.Managers.UserPaymentManager;
using AuroraDAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Aurora
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Default
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region Database

            var connectionString = builder.Configuration.GetConnectionString("Aurora");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            #endregion

            #region Unit Of Work
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Repos
            builder.Services.AddScoped<IProductRepo    , ProductRepo>();
            builder.Services.AddScoped<IUserAddressRepo, UserAddressRepo>();
            builder.Services.AddScoped<IUserPaymentRepo, UserPaymentRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IShippingCompanyRepo, ShippingCompanyRepo>();
            builder.Services.AddScoped<IPaymentDetailRepo  , PaymentDetailRepo  >();
            builder.Services.AddScoped<IOrderItemRepo      , OrderItemRepo      >();
            builder.Services.AddScoped<IOrderRepo          , OrderRepo          >();
            builder.Services.AddScoped<IImageRepo          , ImageRepo          >();
            builder.Services.AddScoped<ICategoryRepo       , CategoryRepo       >();
            builder.Services.AddScoped<ICartItemRepo       , CartItemRepo       >();
            builder.Services.AddScoped<ICartRepo, CartRepo>();
            #endregion

            #region Asp Identity Must Before Auth
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>();
            #endregion

            #region Authuntication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "default";
                options.DefaultChallengeScheme = "default";
            })
                .AddJwtBearer("default",
                options =>
                {
                    var secretKey = builder.Configuration.GetValue<string>("SecretKey");
                    var keyInBytes = Encoding.ASCII.GetBytes(secretKey!);
                    var keySymetricSecKey = new SymmetricSecurityKey(keyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = keySymetricSecKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            #endregion

            #region Authurization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ManagerPolicy", policy =>
                policy.RequireClaim(ClaimTypes.Role, "admin"));

                options.AddPolicy("Data", policy =>
                policy.RequireClaim(ClaimTypes.Role, "ceo"));
            });
            #endregion

            #region Token
            builder.Services.AddScoped<IGenerateToken, GenerateToken>();
            //for fill user
            builder.Services.AddScoped<User>();
            #endregion


            #region Controllers
            builder.Services.AddScoped<IUserManger, UserManger>();
            builder.Services.AddScoped<IUserPaymentManager, UserPaymentManger>();
            builder.Services.AddScoped<IUserAddressManager, UserAddressManager>();
            builder.Services.AddScoped<ICategoryManager , CategoryManager >();
            builder.Services.AddScoped<IShippingCompanyManager, ShippingCompanyManager>();
            builder.Services.AddScoped<IPaymentDetailManager , PaymentDetailManager >();

            #endregion

            var app = builder.Build();

            #region DefaultEnviroment
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            #endregion


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}