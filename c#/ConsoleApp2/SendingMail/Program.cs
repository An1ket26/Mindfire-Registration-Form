using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

class Program
{
    static void Main(string[] args)
    {
        var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
        {
            Credentials = new NetworkCredential("84ea503e277aaa", "2816e62d46ed31"),
            EnableSsl = true
        };
        Attachment data = new Attachment("C:\\Users\\aniket\\Downloads\\photo.jpeg", MediaTypeNames.Application.Octet);

        MailMessage myMail = new MailMessage();
        myMail.From = new MailAddress("mfsi.aniket@gmail.com");
        myMail.To.Add("mfsi.sujeetr@gmail.com");
        myMail.Subject = "HTML Message";
        myMail.IsBodyHtml = true;
        myMail.Body = "<h1 style=color:red>This is test email</h1>";
        myMail.Attachments.Add(data);

        client.Send(myMail);
        Console.WriteLine("Sent");
        Console.ReadLine();
    }
}