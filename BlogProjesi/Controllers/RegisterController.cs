﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);

            if (results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "deneme test";
                wm.TAdd(p);
                return RedirectToAction("Index", "Blog");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); ;

                }


            }
            return View();



        }

    }
}
