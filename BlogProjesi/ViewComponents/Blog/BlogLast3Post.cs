using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = bm.GetLast3Blog();
            return View(values);
        }


    }
}
