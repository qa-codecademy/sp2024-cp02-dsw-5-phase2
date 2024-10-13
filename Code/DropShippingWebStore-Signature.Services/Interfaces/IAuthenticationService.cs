using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropShippingWebStore_Signature.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateTokenAsync(IdentityUser user);

    }
}
