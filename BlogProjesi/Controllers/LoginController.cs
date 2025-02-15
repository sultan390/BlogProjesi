using BlogProjesi.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(UserSignİnViewModel p) // AppUser
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    return RedirectToAction("Index", "Register");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }


        public IActionResult AccessDenied()
        {


            return View();  
        }



    }

}


//Context c = new Context();
//var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail ==
//p.WriterMail && x.WriterPassword == p.WriterPassword);
//if (datavalue != null)
//{
//    HttpContext.Session.SetString("UserName", p.WriterMail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();
//}


//[Authorize]
//[HttpPost]

//public async Task<IActionResult> Index(Writer p)
//{

//    Context c = new Context();
//    var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
//    if (datavalue != null)
//    {
//        var claims = new List<Claim>
//                   {
//                       new Claim(ClaimTypes.Name,p.WriterMail)
//                   };
//        var useridentity = new ClaimsIdentity(claims, "a");
//        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
//        await HttpContext.SignInAsync(principal);

//        return RedirectToAction("Index", "DashBoard");
//    }
//    else
//    {
//        return View();
//    }

//}



