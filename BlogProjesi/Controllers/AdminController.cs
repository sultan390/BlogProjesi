﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{

    [AllowAnonymous]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }









    }
}
