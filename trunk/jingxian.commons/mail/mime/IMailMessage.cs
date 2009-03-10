
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace jingxian.mail.mime
{
    /// <summary>
    /// ��Ϣ�ķ�װ�ӿ�
    /// </summary>
    public interface IMailMessage
    {
        MailAddress From { get; set; }

        MailAddressCollection To { get; set; }

        // ����CC�ֶ�
        MailAddressCollection CarbonCopy { get; set; }

        // ����BCC�ֶ�
        MailAddressCollection BlindCarbonCopy { get; set; }

        string Subject { get; set; }

        string Source { get; set; }

        string TextMessage { get; set; }

        string HeaderFrom { get; set; }

        string HeaderMessageId { get; set; }

        string HeaderCC { get; set; }

        string HeaderBCC { get; set; }

        string HeaderSubject { get; set; }

        string HeaderReferences { get; set; }

        string HeaderTO { get; set; }

        DateTime HeaderDate { get; set; }

        DateTime ReceivedDate { get; set; }

        bool IsNull();
    }
}
