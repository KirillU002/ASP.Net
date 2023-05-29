using System.Net.Mail;
using System.Net;

namespace ASP.Net
{
    public class Service
    {
        private readonly ILogger<Service> logger;

        public Service(ILogger<Service> logger)
        {
            this.logger = logger;
        }

        public void SendEmailDefault(string email)//Этот метод позволяет отправлять email с помощью пакета стандартного пакета 
        {
            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("onlineshop_75@mail.ru", "МониТорг");
                message.To.Add(email);
                message.Subject = "Завершение процедуры регистрации";
                message.Body = "<div style=\"color: red;\">Чтобы закончить регистрации перейдите по <a asp-controller=\"Account\" asp-action=\"Login\">ссылке</a></div>";

                using (SmtpClient client = new SmtpClient("smtp.@gmail.com"))
                {
                    client.Credentials = new NetworkCredential("monitorgonlineshop@gmail.com", "MoniTorgOnlineShop");//Здесь нужно ввести данные акаунта
                    client.Port = 587;
                    client.EnableSsl = true;

                    client.Send(message);
                    logger.LogInformation("Сообщение отправлено успешно!");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);
            }
        }
    }
}
