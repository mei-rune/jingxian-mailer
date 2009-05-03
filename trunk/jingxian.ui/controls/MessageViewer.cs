using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace jingxian.ui.controls
{
    using jingxian.mail;
    using jingxian.mail.mime;

    public partial class MessageViewer : UserControl
    {
        public bool ShowAllAddress = false;
        string CSS = "";

        public MessageViewer()
        {
            InitializeComponent();
        }

        private void generateAddresses(StringBuilder htmlHeader
            , IEnumerable<MailAddress> addresses
            , int limit)
        {

            bool bFirst = true;
            int addresscount = limit;
            if (ShowAllAddress)
                addresscount = int.MaxValue;

            foreach (MailAddress address in addresses)
            {
                if (0 > --addresscount)
                    break;

                if (bFirst)
                {
                    bFirst = false;
                }
                else
                {
                    htmlHeader.Append(", ");
                }

                htmlHeader.Append("<tooltip text='");
                htmlHeader.Append(HTMLHelper.XMLize(address.DisplayName));
                htmlHeader.Append("'>");

                htmlHeader.Append("<a href='");
                htmlHeader.Append(HTMLHelper.XMLize(address.DisplayName));
                htmlHeader.Append("'>");
                htmlHeader.Append(HTMLHelper.XMLize(address.DisplayName) + "</a>");
                htmlHeader.Append("</tooltip>");

            }

            if (0 > addresscount)
            {
                htmlHeader.Append(", <a href='more'>...</a>");
            }
        }

        private string generateHeader(IMailMessage message)
        {
            StringBuilder htmlHeader = new StringBuilder();

            htmlHeader.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            htmlHeader.Append("<html>");
            htmlHeader.Append("<head>");
            htmlHeader.Append("<title> 邮件头信息 </title>");
            htmlHeader.Append("<META NAME=\"Author\" CONTENT=\"梅发坤\">");
            htmlHeader.Append(CSS);
            htmlHeader.Append("</head>");
            htmlHeader.Append("<body>");
            htmlHeader.Append("<table>");

            //generateBeginField( htmlHeader, "headerSubject" );

            htmlHeader.AppendFormat("<tr class=\"{0}\" ><td></td><td>{1}</td><td>", "headerSubject", Resource.SUBJECT ); 
            generateTitle(htmlHeader, message.HeaderSubject, "");
            htmlHeader.Append("</td></tr>");


            htmlHeader.AppendFormat("<tr class=\"{0}\" ><td></td><td>{1}</td><td>", "headerDate", Resource.DATE); 
            htmlHeader.Append("<font size='8' color='#444444'>");
            htmlHeader.Append(message.HeaderDate);
            htmlHeader.Append("</font>");
            htmlHeader.Append("</td></tr>");

            if (null != message.From)
            {
                htmlHeader.AppendFormat("<tr class=\"{0}\" ><td></td><td>{1}</td><td>", "headerFrom", Resource.FROM);

                generateAddresses(htmlHeader, new MailAddress[] { message.From }, 8);

                htmlHeader.Append("</td></tr>");
            }
            if (message.To.Count > 0)
            {
                htmlHeader.AppendFormat("<tr class=\"{0}\" ><td></td><td>{1}</td><td>", "headerTo", Resource.TO);

                generateAddresses(htmlHeader, message.To, 8);

                htmlHeader.Append("</td></tr>");
            }

            if (message.CarbonCopy.Count > 0)
            {
                htmlHeader.AppendFormat("<tr class=\"{0}\" ><td></td><td>{1}</td><td>", "headerFrom", Resource.CC);

                generateAddresses(htmlHeader, message.CarbonCopy, 8);

                htmlHeader.Append("</td></tr>");
            }

            if (message.BlindCarbonCopy.Count > 0)
            {
                htmlHeader.AppendFormat("<tr class=\"{0}\" ><td></td><td>{1}</td><td>", "headerFrom", Resource.BCC);

                generateAddresses(htmlHeader, message.BlindCarbonCopy, 8);

                htmlHeader.Append("</td></tr>");
            }

            htmlHeader.Append("</table>");
            htmlHeader.Append("</body>");
            htmlHeader.Append("/html>");

            return htmlHeader.ToString();
        }


        public void SetMessageInstance(IMailMessage message)
        {
            if (null == message)
                throw new ArgumentNullException( "message" );

            this.titleBrowser.DocumentText = generateHeader(message);
        }

        void OnLinkClicked(Control owner, string url, Rectangle bounds)
        {
            //if (url == "to")
            //{
            //    ContextMenuStrip mnu = ContactAdapter.CreateMenuForMailAddresses(FindForm(), Message.To);

            //    mnu.Show(owner, new Point(bounds.Left, bounds.Bottom));
            //}
            //else if (url == "from")
            //{
            //    ContextMenuStrip mnu = ContactAdapter.CreateMenuForMailAddresses(FindForm(), new MailAddress[] { Message.From });

            //    mnu.Show(owner, new Point(bounds.Left, bounds.Bottom));
            //}
            //else if (url == "cc")
            //{
            //    ContextMenuStrip mnu = ContactAdapter.CreateMenuForMailAddresses(FindForm(), Message.CC);

            //    mnu.Show(owner, new Point(bounds.Left, bounds.Bottom));
            //}
            //else if (url == "bcc")
            //{
            //    ContextMenuStrip mnu = ContactAdapter.CreateMenuForMailAddresses(FindForm(), Message.BCC);

            //    mnu.Show(owner, new Point(bounds.Left, bounds.Bottom));
            //}
            //else if (url == "more")
            //{
            //    ShowMoreBallon(Message.To);

            //}
            //else if (url.StartsWith("http"))
            //{
            //    Process.Start(url);
            //}
            //else
            //{ // clicked on a contact
            //    MailAddress ma = new MailAddress(url);

            //    ContextMenuStrip mnu = ContactAdapter.CreateMenuForMailAddresses(FindForm(), new MailAddress[] { ma });

            //    mnu.Show(owner, new Point(bounds.Left, bounds.Bottom));
            //}
        }
		
    }
}
