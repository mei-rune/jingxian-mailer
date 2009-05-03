
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Net.Mail;

namespace jingxian.mail.mime.RFC2045
{
    public interface IMimeMailMessage : IMailMessage
    {
        IDictionary<string, string> Body { get; }

        IList<IAttachment> Attachments { get; }

        IList<IMimeMailMessage> Messages { get; }

        IList<AlternateView> Views { get; }

        MailMessage ToMailMessage();
    }
}
