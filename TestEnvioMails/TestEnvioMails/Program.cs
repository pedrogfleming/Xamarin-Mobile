using System;
using System.Net;
using System.Net.Mail;
namespace TestEnvioMails
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool exito = Send();
            //Console.WriteLine(exito.ToString());
            //Console.ReadKey();
            try
            {
                SmtpClient client = new SmtpClient("pedropenicilina95@gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("pedropenicilina95@gmail.com", "Aa&12345678");
                MailMessage msg = new MailMessage();
                msg.To.Add("lucas.bayon31@hotmail.com");
                msg.From = new MailAddress("pedropenicilina95@gmail.com");
                msg.Subject = "Mensaje de prueba desde C# .NET";
                msg.Body = "<h1>Mensaje de prueba!!<h1>";
                client.Send(msg);
                Console.WriteLine("successfully Sent Message.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            /// <summary>
            /// Enviar un email
            /// </summary>
            /// <returns>true en caso de éxito, false en caso contrario.</returns>
            static bool Send()
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.From = new MailAddress("mailUsuario@gmail.com", "Nobmre Usuario");
                    //mail.From = new MailAddress("pedropenicilina@yahoo.com", "Pedro Penicilina");
                    mail.To.Add(new MailAddress("mailUsuarioQueRecibe@hotmail.com", "Nobmre Usuario que recibe"));
                    mail.Subject = "Mensaje de prueba desde C# .NET";
                    mail.Body = "<h1>Mensaje de prueba!!<h1>";

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 25;
                        smtp.EnableSsl = false;
                        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                        NetworkCred.UserName = "miMail@gmail.com";
                        NetworkCred.Password = "contraseña";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Send(mail);
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
