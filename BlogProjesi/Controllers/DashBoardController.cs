using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    [AllowAnonymous]
    public class DashBoardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            Context c = new Context();

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();



            //Toplam Blog Sayısı
            ViewBag.v1 = c.Blogs.Count().ToString();
            // Sizin Blog Sayısı
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerid).Count();
            //Toplam Kategori Sayısı
            ViewBag.v3 = c.Categories.Count();
            return View();

        }



    }
}
