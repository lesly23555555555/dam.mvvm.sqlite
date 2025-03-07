using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using System.Windows.Input;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace dam.mvvm.sqlite.Services
{
    class EmailService
    {
        public async Task EnviarCorreoRecuperacion(string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Soporte", "soporte@tudominio.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Recuperación de Contraseña";

            // Contenido del correo
            var body = new TextPart("plain")
            {
                Text = "Haz clic en el siguiente enlace para recuperar tu contraseña: [enlace]"
            };
            message.Body = body;

            // Configuración del servidor SMTP
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, true);  // Configura el servidor SMTP
                    await client.AuthenticateAsync("tuemail@gmail.com", "tucontraseña");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
