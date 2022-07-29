using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Rocky.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        public async Task Execute(string email, string subject, string body)
        {
            MailjetClient client = new MailjetClient("9e869111271dfa8d66f1f5ec713aaaef", "1fd69c0e151d43556436b4690d70b075")
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
         new JObject {
          {
           "From",
           new JObject {
            {"Email", "max.tkachuk228@ukr.net"},
            {"Name", "Maksym"}
           }
          }, {
           "To",
           new JArray {
            new JObject {
             {
              "Email",
              email
             }, {
              "Name",
              "DotNetMastery"
             }
            }
           }
          }, {
           "Subject",
           subject
          }
           ,{
           "HTMLPart",
          body
          }
         }
             });
            await client.PostAsync(request);
        }
    }
}
