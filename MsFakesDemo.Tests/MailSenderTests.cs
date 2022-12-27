using FluentAssertions.Common;
using Microsoft.QualityTools.Testing.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MsFakesDemo.Tests
{


    public class MailSenderTests
    {
        [Fact]
        public void Util_SendMessage()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                // Arrange a scenario to trigger email to testcustomer@contoso.com;

                var msgSent = false;

                System.Net.Mail.Fakes.ShimSmtpClient.AllInstances.SendMailMessage = (client, message) => {
                    msgSent = true;
                    Assert.Equal("testcustomer@contoso.com", message.To[0].Address);
                    // do nothing. do not send actual mail.
                };

                // Act
                MailUtil.SendMessage("Testing", "This is a test", "testcustomer@contoso.com");

                // Assert
                Assert.True(msgSent);
            }
        }
    }
}
