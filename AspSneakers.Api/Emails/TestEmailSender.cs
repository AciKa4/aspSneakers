using AspSneakers.Application.Emails;

namespace AspSneakers.Api.Emails
{
    public class TestEmailSender : IEmailSender
    {
        public void Send(EmailDto message)
        {
            System.Console.WriteLine("Sending email:");
            System.Console.WriteLine("To: " + message.To);
            System.Console.WriteLine("Title: " + message.Title);
            System.Console.WriteLine("Body: " + message.Body);
        }
    }
}
