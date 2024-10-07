﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ServicioEmail
    {
        private SmtpClient server;
        private MailMessage mail;

        public ServicioEmail()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("5.3.pereznicolas@gmail.com", "xcib wejn uzkh efxh");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string destino, string asunto, string cuerpo)
        {
            mail = new MailMessage();
            mail.From = new MailAddress("noresponder@tienda30.com");
            mail.To.Add(destino);
            mail.Subject = asunto;
            mail.Body = cuerpo;
        }

        public void enviarMail()
        {
            try
            {
                server.Send(mail);
            }
            catch (Exception ex)
            {
                // Agregar un mensaje más descriptivo al error
                throw new Exception("Error al enviar el correo: " + ex.Message, ex);
            }
        }

        public void ConfirmarParticipacion(string destino, string nombre, string apellido, string dni)
        {
            string asunto = "Confirmacion de participacion";
            string cuerpo = $@"
         <html>
         <head>
             <style>
                 body {{
                     font-family: Arial, sans-serif;
                     line-height: 1.6;
                 }}
                 .container {{
                     max-width: 600px;
                     margin: 20px auto;
                     padding: 20px;
                     border: 1px solid #ccc;
                     border-radius: 5px;
                     background-color: #f9f9f9;
                 }}
                 .header {{
                     background-color: #007bff;
                     color: #fff;
                     text-align: center;
                     padding: 10px;
                     border-radius: 5px 5px 0 0;
                 }}
                 .invoice-details {{
                     margin-top: 20px;
                     padding: 10px;
                     border: 1px solid #ddd;
                     border-radius: 5px;
                     background-color: #fff;
                 }}
             </style>
         </head>
         <body>
             <div class='container'>
                 <div class='header'>
                     <h1>Confirmación de Participacion</h1>
                 </div>
                 <div class='invoice-details'>
                     <p>Estimado/a <strong>{nombre} {apellido}</strong>,</p>
                     <p>Gracias por participar del sorteo.</p>
                     <h2>Detalle del sorteo:</h2>
                     <table>
                         <tr>
                             <td><strong>Nombre:</strong></td>
                             <td>{nombre} {apellido}</td>
                         </tr>
                         <tr>
                             <td><strong>Dni:</strong></td>
                             <td>{dni}</td>
                         </tr>
                         <tr>
                             <td><strong>Fecha:</strong></td>
                             <td>{DateTime.Now}</td>
                         </tr>
                     </table>
                     <p>Gracias por participar. Si tienes alguna pregunta, no dudes en contactarnos.</p>
                     <p>Saludos,<br/>Equipo19B</p>
                 </div>
             </div>
         </body>
         </html>
    ";




            mail = new MailMessage();
            mail.From = new MailAddress("noresponder@equipo19B.com");
            mail.To.Add(destino);
            mail.Subject = asunto;
            mail.Body = cuerpo;
            mail.IsBodyHtml = true;

            try
            {
                server.Send(mail);
            }
            catch (Exception ex)
            {
                // Agregar un mensaje más descriptivo al error
                throw new Exception("Error al enviar el correo: " + ex.Message, ex);
            }
        }
    }
}
