using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager message = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IActionResult Inbox()
        {

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var values = message.GetInboxListByWriter(writerID);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var values = message.GetSendboxListByWriter(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {

            return View();  
        }


        [HttpPost]
        public IActionResult ComposeMessage (Message2 p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = writerID;  
            p.ReceiverID = 2;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            message.TAdd(p);
            return RedirectToAction("SendBox");
        }


    }
}
