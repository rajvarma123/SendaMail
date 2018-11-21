﻿using System;
using System.Net;
using System.Net.Mail;

namespace EmailSmtp
{
    public class SendMail
    {
        public string Subject;
        public string Body;
        public string From;
        public string To;
        public string Password;
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Credentials
                
                SendMail ss = new SendMail();
                Console.WriteLine("enter your gmail");
                ss.From = Console.ReadLine();
                Console.WriteLine("enter your Password");
                ss.Password = Console.ReadLine();

                Console.WriteLine("enter the subject");
                ss.Subject = Console.ReadLine();
                Console.WriteLine("enter the body");
                ss.Body = Console.ReadLine();
                Console.WriteLine("Enter for to address");
                ss.To = Console.ReadLine();
                var credentials = new NetworkCredential(ss.From, ss.Password);
                // Mail message
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
            catch (Exception ex)
            {
                Console.WriteLine("Error in sending email: " + ex.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Email sccessfully sent");
            Console.ReadKey();
        }
    }
}