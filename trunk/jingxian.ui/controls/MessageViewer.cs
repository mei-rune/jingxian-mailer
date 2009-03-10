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
        bool ShowAllAddress = false;
        string CSS = "";

        public MessageViewer()
        {
            InitializeComponent();
        }


        private void generateTitle(StringBuilder htmlHeader
            , string caption
            , string captionURL)
        {
            if (string.IsNullOrEmpty(captionURL))
            {
                htmlHeader.Append("<a href='");
                htmlHeader.Append(captionURL);
                htmlHeader.Append("'>");
                htmlHeader.Append(HTMLHelper.XMLize(caption));
                htmlHeader.Append("</a>");
            }
            else
            {
                htmlHeader.Append(HTMLHelper.XMLize(caption));
            } 
        }


        private void generateHeaderHtml(StringBuilder htmlHeader
            , IEnumerable<MailAddress> addresses
            , int limit)
        {

            bool bFirst = true;
            int addresscount = limit;
            if (ShowAllAddress)
                addresscount = int.MaxValue;

            using (IEnumerator<MailAddress> enumerator = addresses.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (0 > --addresscount)
                        break;

                    MailAddress address = enumerator.Current;
                    if (bFirst == false)
                    {
                        htmlHeader.Append(", ");
                        bFirst = false;
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
            }

            if (0 > addresscount)
            {
                htmlHeader.Append(", <a href='more'>...</a>");
            }
        }

        private string GenerateHeaderHtml(IMailMessage message)
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

            generateBeginTitle( "headerSubject" );
            generateTitle(htmlHeader, Resource.SUBJECT, "" );
            generateEndTitle( );

            generateBeginField("headerSubject");
            generateTitle(htmlHeader, message.HeaderSubject, "");
            generateEndField();


            htmlHeader.Append("<font size='13'>");
            HTMLHelper.GenerateSubstringWithTooltip(htmlHeader, message.Subject, 82);
            htmlHeader.Append("</font>");

            htmlHeader.Append("<br/><font size='8' color='#444444'>");
            htmlHeader.Append(message.HeaderDate);
            htmlHeader.Append("</font>");

            if (null != message.From)
            {
                GenerateHeaderHtml(htmlHeader, Resource.FROM, "from", new MailAddress[] { message.From }, 8);
            }
            if (message.To.Count > 0)
            {
                GenerateHeaderHtml(htmlHeader, "To:", "to", message.To, 8);
            }

            if (message.CarbonCopy.Count > 0)
            {
                GenerateHeaderHtml(htmlHeader, "CC:", "cc", message.CC, 8);
            }

            if (message.BlindCarbonCopy.Count > 0)
            {
                GenerateHeaderHtml(htmlHeader, "BCC:", "bcc", message.BCC, 8);
            }



            htmlHeader.Append("</table>");
            htmlHeader.Append("</body>");
            htmlHeader.Append("/html>");

            return htmlHeader.ToString();
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
