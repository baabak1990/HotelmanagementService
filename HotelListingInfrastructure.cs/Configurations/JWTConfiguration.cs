using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelListingInfrastructure.cs.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


namespace HotelListingInfrastructure.cs.Configurations
{
    public static class JWTConfiguration
    {
        public static IServiceCollection JwtConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //As You can see this section came from AppSetting.json file
            var jwtSettings = configuration.GetSection("jwt");
            //We create our variable in Environment (8 ;;
            var key = Environment.GetEnvironmentVariable("KEY");

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        //This Issuer name came from appSetting.json File
                        ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    };
                });


            services.AddScoped<IAuthManager, AuthManager>();

            return services;
        }
    }
}
