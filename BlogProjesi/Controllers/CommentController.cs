using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {

            return PartialView();
        }
        [Authorize]
        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            p.BlogID = 1;
            cm.CommentAdd(p);
            return PartialView();
        }



        public PartialViewResult CommentListByBlog(int id)
        {

            var values = cm.GetList(id);
            return PartialView(values);

        }


    }
}
/*
  [HttpPost]
        public IActionResult Index(Contact p)
        {
            p.ContanctDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContactStatus = true;
            cm.ContactAdd(p);
            return RedirectToAction("Index", "Blog");
        }
 */