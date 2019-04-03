﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BasitFormUygulaması.Models;

namespace BasitFormUygulaması.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(FormModel model)
        {
             MailMessage _mm = new MailMessage();



            _mm.SubjectEncoding = Encoding.Default;
            _mm.Subject = model.AdiSoyadi;
            _mm.BodyEncoding = Encoding.Default;
            _mm.Body = model.Mesaj;

            _mm.From = new MailAddress(ConfigurationManager.AppSettings["emailAccount"]);
            _mm.To.Add("mert.denizdelen@hotmail.com");


            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.Host = ConfigurationManager.AppSettings["emailHost"];
            _smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
            _smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailAccount"], ConfigurationManager.AppSettings["emailPassword"]);
            _smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["emailSLLEnable"]);

            _smtpClient.Send(_mm);

            TempData["Basarili"] = "Teşekürler en kısa zamanda tafarınıza dönüş yapılacaktır.";

            return RedirectToAction("Index");
        }
    }
}