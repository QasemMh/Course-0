using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //enble POP & IMAP >> outlook.com > setting > sync mail > enable POP option > yes 
                //outlook email: asdfrgtbgh@outlook.com
                //pass: kasem2000

                using SmtpClient mySmtpClient = new SmtpClient("smtp.office365.com", 587);
                mySmtpClient.EnableSsl = true;

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                NetworkCredential basicAuthenticationInfo = new
                  NetworkCredential("asdfrgtbgh@outlook.com", "kasem2000");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress("asdfrgtbgh@outlook.com", "Market Store Admin");

                //Send mail to:
                MailAddress to = new MailAddress("qm84028@gmail.com", "Customer:");
                using MailMessage myMail = new MailMessage(from, to);



                // set subject and encoding
                myMail.Subject = "Invoice - MarketStore";
                myMail.SubjectEncoding = Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "<h1>Hello</h1><h3>Test Test Test</h3>";
                myMail.BodyEncoding = Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                await mySmtpClient.SendMailAsync(myMail);
                Console.WriteLine("Email Has Been Send");

            }

            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
