using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BmesRestApi.Infrastructure
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddJwtAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            var settings = configuration.GetSection("AuthSettings");
            var authSettings = settings.Get<AuthSettings>();

            services.Configure<AuthSettings>(settings);

            var key = Encoding.ASCII.GetBytes(authSettings.Key);

            services.AddAuthorization();

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }
    }
}
