using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        Context c = new Context();
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);

           
           // ViewBag.v3 = c.Categories.Count();


        }

    }
}
