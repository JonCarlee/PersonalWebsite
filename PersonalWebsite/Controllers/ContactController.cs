using Microsoft.AspNet.Identity;
using PersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalWebsite.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(ContactMessage ContactForm){
        if(ModelState.IsValid){
            var Emailer = new EmailService();
            var mail = new IdentityMessage{
                Subject = ContactForm.Subject,
                Destination = ConfigurationManager.AppSettings["ContactEmail"],
                Body = "You have recieved a new contact form submission from " + ContactForm.Name +
                " (" + ContactForm.FromEmail + ") with the following contents:" + "<br>" + ContactForm.Body};
                Emailer.SendAsync(mail);
                ViewBag.MessageSent = "Your message has been delivered successfully!";
            }
        return View();
        }
    }
}