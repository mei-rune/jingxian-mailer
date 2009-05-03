
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
        MailAddress From { get; }

        MailAddressCollection To { get; }

        // ����CC�ֶ�
        MailAddressCollection CarbonCopy { get; }

        // ����BCC�ֶ�
        MailAddressCollection BlindCarbonCopy { get; }

        string TextMessage { get; }

        string HeaderFrom { get; }

        string HeaderMessageId { get; }

        string HeaderCC { get; }

        string HeaderBCC { get; }

        string HeaderSubject { get;}

        string HeaderReferences { get; }

        string HeaderTO { get;}

        DateTime HeaderDate { get; }

        DateTime ReceivedDate { get; }

        bool IsNull();
    }
}
