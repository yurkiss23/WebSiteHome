﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using WebSiteHome.Models;

namespace WebSiteHome.Controllers
{
    public class MessageController : ApiController
    {
        // GET: api/Messege
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Messege/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Message
        public IHttpActionResult Post(UserAddViewModel model)
        {
            MailMessage mail = new MailMessage("terranet23@gmail.com", model.Email);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("terranet23@gmail.com", "?t1e2r3r4a5n6e7t?");
            client.Host = "smtp.gmail.com";
            mail.Subject = model.FirstName;// + " " + model.LastName;
            mail.Body = "user added";
            mail.IsBodyHtml = true;
            client.Send(mail);

            return Ok();
        }

        // PUT: api/Messege/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Messege/5
        public void Delete(int id)
        {
        }

        
    }
}
