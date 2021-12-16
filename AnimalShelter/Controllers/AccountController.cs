﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.ViewModels;

namespace AnimalShelter.Controllers
{
    public class AccountController : Controller
    {
        //private  UserContext db;
        //public AccountController(UserContext context)
        //{
        //    db = context;
        //}
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (DataAccess.IsLoginCorrect(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if(DataAccess.RegisterUser(model))
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
    }
}