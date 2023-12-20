using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Inventory.Extensions
{

    public static class AddAuthenticationBearer
    {
        public static WebApplicationBuilder AddAuth(this WebApplicationBuilder builder)
        {
            var secretKey = builder.Configuration.GetSection("JwtOptions:SecretKey").Value;

            builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,

                    ValidAudience = builder.Configuration.GetSection("JwtOptions:Audience").Value,
                    ValidIssuer = builder.Configuration.GetSection("JwtOptions:Issuer").Value,


                    IssuerSigningKey = secretKey != null
                        ? new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                        : null
                };
            });

            return builder;
        }
    }
}
