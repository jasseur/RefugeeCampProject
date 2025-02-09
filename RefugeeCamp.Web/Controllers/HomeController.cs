﻿using System.Web.Mvc;

using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using RefugeeCamp.Web.Models.EducationModels;

namespace RefugeeCamp.Web.Controllers
{
    public class HomeController : Controller
    {
        //by fayrouz
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("icrcheadquarters1@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("fayrouz.ouerghi@esprit.tn");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "fayrouz.ouerghi@esprit.tn",  // replace with valid value
                        Password = "killmelater@22"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        

        public ActionResult Sent()
        {
            return View();
        }

//end by fayrouz
        public ActionResult Index(string test)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}