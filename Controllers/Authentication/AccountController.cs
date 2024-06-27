﻿using Identity.Models;
using Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers.Authentication
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser>userManager,SignInManager<IdentityUser>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var chkEmail = await userManager.FindByEmailAsync(model.Email);
                    if (chkEmail != null) {
                        ModelState.AddModelError(string.Empty, "Email already exist");
                        return View(model);
                    }
                    var user = new IdentityUser
                    {
                        UserName = model.Email,
                        Email = model.Email
                    };
                    var result=await userManager.CreateAsync(user,model.Password);
                    if(result.Succeeded)
                    {
                        await signInManager.SignInAsync(user,isPersistent:false);
                        return RedirectToAction("Index", "Home");
                    }
                    if (result.Errors.Count() > 0)
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }

                    }
                }
            }catch(Exception ex)
            {

            }
            return View(model);

        }
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityUser chkEmail = await userManager.FindByEmailAsync(model.Email);
                    if (chkEmail == null)
                    {
                        ModelState.AddModelError(string.Empty, "Email not exist");
                        return View(model);
                    }
                    if(await userManager.CheckPasswordAsync(chkEmail,model.Password)==false) {
                        ModelState.AddModelError(string.Empty, "Invalid Credentials");
                        return View(model);
                    }
                    var result=await signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,lockoutOnFailure:false);
                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid Login Credentials");

                }

            } catch (Exception ex) { }
            return View(model);

        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");

        }

    }
}
