using Bcl.Messaging;

namespace Bcl.MessagingTests
{
    internal class SendEmailMessage : MessageBase
    {
        public string Body { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string ToEmails { get; set; }
    }
}