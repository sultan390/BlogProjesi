using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {

        Message2Manager message = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();


        [AllowAnonymous]
        public IActionResult Index()
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

        public IActionResult MessageDetails(int id)
        {
            var value = message.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            p.SenderID = writerID;
            p.ReceiverID = writerID;    //2
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.TAdd(p);
            return RedirectToAction("Index");

        }

    }

}
//[HttpPost]

//public IActionResult EditBlog(Blog p)
//{
//    p.WriterID = 1;
//    p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
//    p.BlogStatus = true;
//    bm.TUpdate(p);
//    return RedirectToAction("BlogListByWriter");
//}



