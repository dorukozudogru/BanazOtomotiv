using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BanazOtomotiv.Models;
using System.Net.Mail;

namespace BanazOtomotiv.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public void SendEmail(string FullName, string Email, string Phone, string Message)
        {
            Guid newGuid = Guid.NewGuid();
            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = null;
            smtp.Credentials = new System.Net.NetworkCredential("banazsigorta@gmail.com", "Banaz26.,");

            msg.IsBodyHtml = true;
            msg.From = new MailAddress(Email, FullName);
            msg.Sender = new MailAddress(Email, FullName);
            msg.To.Add("satisresepsiyon@banazotomotiv.com.tr");
            //msg.To.Add("dorukozudogru.oplog@gmail.com");

            msg.Subject = "BanazOtomotiv.com.tr Form E-Postası - " + newGuid;
            msg.Body = "<table><tr><td><b>İsim Soyisim: </b></td><td>" + FullName + "</td></tr>" +
                       "<tr><td><b>Email: </b></td><td>" + Email + "</td></tr>" +
                       "<tr><td><b>Telefon: </b></td><td>" + Phone + "</td></tr>" +
                       "<tr><td><b>Mesaj: </b></td><td>" + Message + "</td></tr></table>";
            smtp.Send(msg);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public class EmailViewModel
        {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Message { get; set; }
        }
    }
}
