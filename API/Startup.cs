using Core;
using Core.DTO;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API;

public class Startup
{
}

public static class DependencyInject
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        if (builder == null)
        {
            return;
        }

        builder.Services
               .AddAuthentication(x =>
               {
                   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
               })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = true;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidIssuer = AppSettings.JWT?.Issuer,
                       ValidateAudience = true,
                       ValidAudience = AppSettings.JWT?.Issuer,
                       ValidateIssuerSigningKey = true,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.Zero,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JWT?.Key ?? string.Empty))
                   };
                   x.Events = new JwtBearerEvents
                   {
                       OnAuthenticationFailed = context =>
                       {
                           if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                           {
                               context.Response.Headers.Append("Token-Expired", "true");
                           }
                           return Task.CompletedTask;
                       }
                   };
               });
        builder.Services.InjectCore();
        builder.Services.InjectInfrastructure();
    }
}
