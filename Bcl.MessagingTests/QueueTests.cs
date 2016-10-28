using System;
using Xunit;
using Bcl.Messaging;

namespace Bcl.MessagingTests
{
    public class QueueTests
    {
        [Fact]
        public void TestMethod1()
        {
            var msg = new SendEmailMessage
            {
                FromEmail = "jonsmith@gmail.com",
                ToEmails = "bobjones@gmail.com",
                Subject = "Covariance is hard",
                Body = "Lets hope this example works"
            };

            var q = new Queue();

            q.Enqueue(msg);

            var msgOut = q.Dequeue();

            Assert.Equal(msgOut.GetType(), msg.GetType());
        }
    }
}
