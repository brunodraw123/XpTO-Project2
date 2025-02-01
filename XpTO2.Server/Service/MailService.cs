using System.Net.Mail;
using System.Net;
using XPTOApp.Model;
using XPTOApp.Controller;

namespace XpTO2.Server.Service
{
    public class MailService
    {
        private string emailFromAddress = "bruno.oliveira2002@yahoo.com.br"; //Sender Email Address  
        private string smtpAddress = "smtp.mail.yahoo.com";
        private string password = "trzigyslwjzrspja"; //Sender Password  (in yahoo case, use app password than e-mail password)
        private string emailToAddress = ""; //Receiver Email Address  
        private string subject = "Pedido concluido";
        private bool enableSSL = true;
        private int portNumber = 587;

        public void SendEmail(OrderViewModel order)
        {
            this.emailToAddress = order.CustomerMail;
            this.subject = $"Pedido - {order.OrderID} | {order.CustomerName} : Concluído";

            string TextBody(OrderViewModel model)
            {

                string textbody = $"<HTML> " +
                    $" <BODY><H3><b>Pedido:</b> {order.OrderID}</H3>" +
                    $" <p><b>Bebida:</b> {order.Drink.Description}</p>" +
                    $" <p><b>Acompanhamento:</b> {order.AccompanimentFood.Description}</p>" +
                    $" <p><b>Prato principal:</b> {order.MainFood.Description}</p>" +
                    $" <p><b>Sobremesa:</b> {order.Dessert.Description}</p>" +
                    $" <p><b>Cliente:</b> {order.CustomerName}</p>" +
                    $" <p>Caro cliente {order.CustomerName} favor retirar o pedido, ou aguardar em sua mesa. </p>" +

                    $" </BODY> </HTML>";
                return textbody;
            }

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = TextBody(order);
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}
