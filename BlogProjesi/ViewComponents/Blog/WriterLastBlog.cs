using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = bm.GetBlogListByWriter(1);
            return View(values);
        }
    }
}
