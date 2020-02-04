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

        [HttpPost]
        public ActionResult SendEmail(string FullName, string Email, string Phone, string Message)
        {
            Guid newGuid = Guid.NewGuid();
            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient("mail.banazotomotiv.com.tr");

            smtp.Port = 587;
            smtp.Host = "mail.banazotomotiv.com.tr";
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = null;
            smtp.Credentials = new System.Net.NetworkCredential("no-reply@banazotomotiv.com.tr", "BAnaz26.,");

            msg.IsBodyHtml = true;
            msg.From = new MailAddress("no-reply@banazotomotiv.com.tr", FullName);
            msg.To.Add("satisresepsiyon@banazotomotiv.com.tr");
            //msg.To.Add("dorukozudogru.oplog@gmail.com");

            msg.Subject = "BanazOtomotiv.com.tr Form E-Postası - " + newGuid;
            msg.Body = "<table><tr><td><b>İsim Soyisim: </b></td><td>" + FullName + "</td></tr>" +
                       "<tr><td><b>Email: </b></td><td>" + Email + "</td></tr>" +
                       "<tr><td><b>Telefon: </b></td><td>" + Phone + "</td></tr>" +
                       "<tr><td><b>Mesaj: </b></td><td>" + Message + "</td></tr></table>";
            try
            {
                smtp.Send(msg);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
