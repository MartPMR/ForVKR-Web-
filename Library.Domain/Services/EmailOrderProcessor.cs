using Library.Domain.Entities;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Library.Services
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            StringBuilder body = new StringBuilder()
                .AppendLine("Новый заказ обработан")
                .AppendLine("---")
                .AppendLine("Товары:");

            foreach (var line in cart.Lines)
            {
                var subtotal = line.book.YEAR_PUB;
                body.AppendFormat("{0} x {1} (итого: {2:c}",
                    line.Quantity, line.book.NAME_BOOK, subtotal);
            }

            body.AppendLine("Общая стоимость")
                .AppendLine("---")
                .AppendLine("Доставка:")
                .AppendLine(shippingInfo.Name)
                .AppendLine(shippingInfo.Line1);

            Task.Run(() =>
            {
                using (var smtpClient = new SmtpClient())
                {
                    System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage();
                    mm.To.Add(mm.From);
                    mm.Subject = "Новый заказ отправлен!";
                    mm.Body = body.ToString();
                    try { smtpClient.Send(mm); }
                    catch (Exception error) { }
                }
            });

        }
    }
}