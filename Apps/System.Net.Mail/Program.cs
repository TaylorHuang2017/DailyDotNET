using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

//System.Net.Mail 详细讲解 https://blog.csdn.net/liyanwwww/article/details/5507498
namespace SendMail 
{
    class Program
    {
        static void Main(string[] args)
        {
            SendingMail();
            //Console.ReadLine();
        }

        private static void SendingMail()
        {
            string smtpService = "smtp.qq.com";
            string sendEmail = "2730891246@qq.com";
            string sendpwd = "wjfevevlekofdefb";

            MailAddress sendAddress = new MailAddress(sendEmail);
            MailAddress receiveAddress = new MailAddress("taylorw@126.com");

            //构造一个Email的Message对象 内容信息
            MailMessage mailMessage = new MailMessage(sendAddress, receiveAddress);
            mailMessage.Subject = "测试邮件" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss");
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = "测试邮件发送成功！！！";
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            //SMTP客户端
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Host = smtpService;
            //smtpclient.Port = "";
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.EnableSsl = true;
            try
            {
                smtpclient.UseDefaultCredentials = false;
                NetworkCredential networkCredential = new NetworkCredential(sendEmail, sendpwd);
                smtpclient.Credentials = networkCredential;
                smtpclient.Send(mailMessage);
                Console.WriteLine("发送邮件成功");

            }
            catch (System.Net.Mail.SmtpException ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
