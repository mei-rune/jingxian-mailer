
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace jingxian.mail.mime
{
    /// <summary>
    /// 消息的封装接口
    /// </summary>
    public interface IMailMessage
    {
        MailAddress From { get; }

        MailAddressCollection To { get; }

        // 就是CC字段
        MailAddressCollection CarbonCopy { get; }

        // 就是BCC字段
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
