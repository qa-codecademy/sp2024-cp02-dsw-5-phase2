using DropShippingWebStore_Signature.Services.Interfaces;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace DropShippingWebStore_Signature.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly string _apiKey;
        private readonly string _secretKey ;

        public EmailService(string apiKey, string secretKey)
        {
            _apiKey = apiKey;
            _secretKey = secretKey;
        }

        public async Task SendEmailAsync(string orderId, string content)
        {
            MailjetClient client = new MailjetClient(_apiKey,_secretKey);

            // construct your email with builder
            var emailTemp = new TransactionalEmailBuilder()
                   .WithFrom(new SendContact("sender email","sender name "))
                   .WithSubject(orderId)
                   .WithTextPart(content)
                   .WithHtmlPart("")
                   //.WithHtmlPart($"<h1>{content}</h1>")
                   .WithTo(new SendContact("reciever email"))
                   .Build();

            // invoke API to send email
            var response = await client.SendTransactionalEmailAsync(emailTemp);

        }
    }
}
       