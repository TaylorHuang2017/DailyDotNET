using ConfigServices;
using LogServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailServices
{
    public class MailService : IMailService
    {
        private readonly ILogProvider log;
        private readonly IConfigService config;

        public MailService(ILogProvider log, IConfigService config)
        {
            this.log = log;
            this.config = config;
        }
        public void Send(string title, string to, string body)
        {
            this.log.LogInfo("ready to start");
            string smtpServer = this.config.GetValue("SmtpServer");
            Console.WriteLine($"server address: {smtpServer}");
            Console.WriteLine($"Mail sent. Title: {title}, To: {to}");
            this.log.LogInfo("completed");

        }
    }
}
