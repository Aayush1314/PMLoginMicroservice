using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LoginMicroservice.Data;
using LoginMicroservice.Interfaces;
using LoginMicroservice.Services;
using LoginMicroservice.Repository;

namespace LoginMicroservice.Extensions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config )
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAccountRepo, AccountRepo>();

            services.AddDbContext<ProtfolioDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
