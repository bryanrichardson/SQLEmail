using System.Net;
using System.Net.Mail;

namespace SqlEmail
{
    public class SqlEmail
    {
        [Microsoft.SqlServer.Server.SqlProcedure(Name="SendSqlMail")]
        public static void SendSqlMail(string recipients, string cc, string bcc, string subject, string from, string body,
                                string attachments, string server, int port, string user, string pwd)
        {
            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(from);
                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = true;

                PopulateAddresses(recipients, msg.To);
                PopulateAddresses(recipients, msg.CC);
                PopulateAddresses(recipients, msg.Bcc);
                AddAttachments(attachments, msg);

                var smtp = new SmtpClient(string.IsNullOrEmpty(server) ? "localhost" : server, port == 0 ? 25 : port);
                if (!string.IsNullOrEmpty(user))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(user,pwd);
                }
                smtp.Send(msg);
            }
        }

        private static void AddAttachments(string attachments, MailMessage msg)
        {
            if (string.IsNullOrEmpty(attachments)) return;
            if (msg == null) return;
            var split = attachments.Split(';');
            foreach (var s in split)
                msg.Attachments.Add(new Attachment(s));
        }

        private static void PopulateAddresses(string recipients, MailAddressCollection collection)
        {
            if (string.IsNullOrEmpty(recipients)) return;
            if (collection == null) return;
            var split = recipients.Split(';');
            foreach (var s in split)
                collection.Add(s);
        }
    }
}
