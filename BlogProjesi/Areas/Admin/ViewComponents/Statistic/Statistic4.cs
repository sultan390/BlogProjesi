using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.v3 = c.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDescription).FirstOrDefault();
            return View();

        }


        // weather api xml kodları çağırmak için 
        // ankara 
        // d5cecc14d0205c6ea4fa44767bb1291c
        // http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid
    }
}
