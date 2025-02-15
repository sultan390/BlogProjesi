using BlogProjesi.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    [AllowAnonymous]

    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        UserUpdateViewModel model = new UserUpdateViewModel();
        Context c = new Context();

        private readonly UserManager<AppUser> _userManager;


        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag().v2 = writerName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }


        public IActionResult WriterMail()
        {
            return View();
        }


        public IActionResult WriterLayout()
        {
            return View();
        }


        public IActionResult Test()
        {
            return View();
        }


        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }


        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }


        [HttpGet]

        public async Task<IActionResult> WriterEditProfile()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.mail;
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.UserName = model.username;
            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "DashBoard");
        }


        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }


        // alt metotda görsel ekleme yapıldı ama hata sayfasıana attığı için bırakıldı. tekrar bak.

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();

            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
                return RedirectToAction("Index", "DashBoard");
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);



            return View();
        }





    }
}




//public IActionResult WriterEditProfile()
//{
//    UserManager userManager = new UserManager(new EfUserRepository());
//    userManager.TUpdate(p);
//    return RedirectToAction("Index", "Dashboard");
//WriterValidator wl = new WriterValidator();
//ValidationResult results = wl.Validate(p);
//if (results.IsValid)
//{
//    wm.TUpdate(p);
//    return RedirectToAction("Index", "Dashboard");

//}
//else
//{
//    foreach (var item in results.Errors)
//    {
//        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

//    }

//}
//return View();

//}
