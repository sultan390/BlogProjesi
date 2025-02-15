using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    [AllowAnonymous]
    public class ErorPageController : Controller
    {
        public IActionResult Eror1(int code)
        {
            return View();
        }
    }
}
