using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using todoapp.webui.Identity;
using todoapp.webui.Models;

namespace todoapp.webui.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index","Home");
            }
            var user = new User();
            user.UserName = model.UserName;
            var result = await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
            return RedirectToAction("Index","Home");
            }
            
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index","Home");
            }
            var user = _userManager.FindByNameAsync(model.UserName);
            if(user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Wrong username or password.");
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

       
    }
}