using SQL_Database_Generator.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace SQL_Database_Generator.Models
{
    public class MailInfo
    {
        public string SenderAddress { get; set; } = string.Empty;
        public List<string> RecepientAddresses { get; set; }
        public List<string> BccRecepientAddress { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public MailMessage MailMessage
        {
            get
            {
                VerifyMailContents();

                MailAddress sender = new MailAddress(SenderAddress, "FOI Programsko inženjerstvo");
                MailAddressCollection recepients = GetMailAddresses(RecepientAddresses);
                MailAddressCollection bccRecepient = GetMailAddresses(BccRecepientAddress);

                return CreateEmail(sender, recepients, bccRecepient);
            }
        }

        private MailAddressCollection GetMailAddresses(List<string> emails)
        {
            MailAddressCollection mailAdressCollection = new MailAddressCollection();

            if (emails is null)
            {
                return mailAdressCollection;
            }

            var nonEmptyEmails = emails.FindAll((email) => !string.IsNullOrWhiteSpace(email));

            foreach (string emailAddress in nonEmptyEmails)
            {
                mailAdressCollection.Add(new MailAddress(emailAddress));
            }

            return mailAdressCollection;
        }

        private MailMessage CreateEmail(MailAddress sender, MailAddressCollection recepients, MailAddressCollection bccRecepients)
        {
            MailMessage email = new MailMessage
            {
                From = sender,
                Subject = Subject,
                Body = Message,
            };

            foreach (MailAddress mail in recepients)
            {
                email.To.Add(mail);
            }

            foreach (MailAddress mail in bccRecepients)
            {
                email.Bcc.Add(mail);
            }

            return email;
        }

        private void VerifyMailContents()
        {
            SenderAddress.ThrowIfNullOrWhiteSpace(nameof(SenderAddress));
            RecepientAddresses.ThrowIfNull(nameof(RecepientAddresses));
            if (RecepientAddresses.Count == 0)
            {
                throw new ArgumentException(nameof(RecepientAddresses));
            }
            Subject.ThrowIfNullOrWhiteSpace(nameof(Subject));
            Message.ThrowIfNullOrWhiteSpace(nameof(Message));
        }
    }
}
