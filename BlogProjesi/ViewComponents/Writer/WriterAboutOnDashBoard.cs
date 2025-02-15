using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents.Writer
{
    public class WriterAboutOnDashBoard : ViewComponent
    {
        Context c = new Context();
        WriterManager wm = new WriterManager(new EfWriterRepository());



        public IViewComponentResult Invoke()
        {
            string? username = User.Identity.Name;
            ViewBag.v = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.GetWriterById(writerID);
            return View(values);
        }

    }
}
