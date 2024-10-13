
using DropShippingWebStore_Signature.DataAccess;
using DropShippingWebStore_Signature.Services.Implementations;
using DropShippingWebStore_Signature.Services.Interfaces;
using Mailjet.Client.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlTypes;

namespace DropShippingWebStore_Signature.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services,string sqlServerString)
        {
            services.AddDbContext<SignatureDbContext>(options => options.UseSqlServer(sqlServerString));
        }

        public static void InejctEmailService(IServiceCollection services, IConfiguration configuration) {

            var apiKey = configuration.GetValue<string>("MailjetConfig:ApiKey");
            var secretKey = configuration.GetValue<string>("MailjetConfig:SecretKey");

            services.AddTransient<IEmailService>(provider => new EmailService(apiKey, secretKey));
        }
        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }


    }
}
