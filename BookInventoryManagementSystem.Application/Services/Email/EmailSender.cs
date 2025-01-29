using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace BookInventoryManagementSystem.Application.Services.Email;

public class EmailSender(IConfiguration _configuration) : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var fromAddress = _configuration["EmailSettings:DefaultEmailAddress"];
        var smtpServer = _configuration["EmailSettings:Server"];
        var smtpPort = _configuration["EmailSettings:Port"];

        if (string.IsNullOrEmpty(fromAddress))
        {
            throw new InvalidOperationException("The email sender address is not configured.");
        }
        if (string.IsNullOrEmpty(smtpServer))
        {
            throw new InvalidOperationException("The email server is not configured.");
        }
        if (string.IsNullOrEmpty(smtpPort))
        {
            throw new InvalidOperationException("The email port is not configured.");
        }

        var message = new MailMessage
        {
            From = new MailAddress(fromAddress),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };

        message.To.Add(email);

        using var client = new SmtpClient(smtpServer, int.Parse(smtpPort))
        {
            EnableSsl = false,
            UseDefaultCredentials = true
        };

        await client.SendMailAsync(message);
    }
}
