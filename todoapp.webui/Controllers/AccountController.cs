using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using todoapp.webui.Extensions;
using todoapp.webui.Identity;
using todoapp.webui.Models;

namespace todoapp.webui.Controllers
{
    [AutoValidateAntiforgeryToken] // Shortcut
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
        [ValidateAntiForgeryToken]

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
                // generate token
                var tokenGenerated = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail","Account",new{
                    userId = user.Id,
                    token = tokenGenerated
                });
                user.Token = url;
                await _userManager.UpdateAsync(user);

                return RedirectToAction("Index","Home");
            }
            
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index","Home");
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user == null)
            {
                TempData.Put("msg", new TempDataModel{
                        Message = "No user found.",
                        ClassAtr = "info"
                    });
                // AccControlMessage("No user found.", "info");
                return RedirectToAction("Index", "Home");
            }
            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                TempData.Put("msg", new TempDataModel{
                        Message = "Please confirm your email.",
                        ClassAtr = "info"
                    });
                TempData["token"] = user.Token;
                return RedirectToAction("Index", "Home");
            }
            
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData.Put("msg", new TempDataModel{
                        Message = "Failed to log in.",
                        ClassAtr = "info"
                    });
            
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId == null || token == null)
            {
            return RedirectToAction("Index", "Home");

            }
            var user = await _userManager.FindByIdAsync(userId);
            if(user!= null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if(result.Succeeded)
                {
                    TempData.Put("msg", new TempDataModel{
                        Message = "Your Account Has Been Confirmed",
                        ClassAtr = "success"
                    });
                    return RedirectToAction("Index", "Home");
                }
                
            }
            TempData.Put("message", new TempDataModel{
                    Message = "Failed to confirm.",
                    ClassAtr = "danger"
                });
           
            return RedirectToAction("Index", "Home");

        }

       

       
    }
}