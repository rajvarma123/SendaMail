using System;
using System.Net;
using System.Net.Mail;

namespace EmailSmtp
{
    public class SendMail
    {
        public string Subject { get; set; }
        public string Body;
        public string From;
        public string To;
        public string Password;
    }
   public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Credentials

                SendMail sendmail = new SendMail();
                Console.WriteLine("enter your gmail");
                sendmail.From = Console.ReadLine();
                Console.WriteLine("enter your Password");
                sendmail.Password = Console.ReadLine();

                Console.WriteLine("enter the subject");
                sendmail.Subject = Console.ReadLine();
                Console.WriteLine("enter the body");
                sendmail.Body = Console.ReadLine();
                Console.WriteLine("Enter for to address");
                sendmail.To = Console.ReadLine();
                // Mail message
                SendEmailToEmployee(sendmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in sending email: " + ex.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Email sccessfully sent");
            Console.ReadKey();
        }

        private static void SendEmailToEmployee(SendMail ss)
        {
            var credentials = new NetworkCredential(ss.From, ss.Password);

            var mail = new MailMessage()
            {

                From = new MailAddress(ss.From),
                Subject = ss.Subject,
                Body = ss.Body,
            };

            mail.To.Add(new MailAddress(ss.To));

            // Smtp client
            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };

            // Send it...         
            client.Send(mail);
        }
    }
}