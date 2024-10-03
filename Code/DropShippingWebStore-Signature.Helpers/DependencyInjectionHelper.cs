
using DropShippingWebStore_Signature.DataAccess;
using Microsoft.EntityFrameworkCore;
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
    }
}
