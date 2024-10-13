using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropShippingWebStore_Signature.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string orderId, string content);
    }
}
