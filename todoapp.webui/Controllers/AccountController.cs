using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
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
        
        // [HttpPost]
        public IActionResult Premium(DonationModel model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-y3ztvRIaAUb4XVHV8Hejfb5PJzQcwZCf";
            options.SecretKey = "sandbox-sAh6sH0MmgmTGxKhZYxpgALqi7UWxZFR";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";
                    
            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = "1";
            request.PaidPrice = model.DonationAmount;
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.FirstName;
            paymentCard.CardNumber = "5528790000000008";
            paymentCard.ExpireMonth = "12";
            paymentCard.ExpireYear = "2030";
            paymentCard.Cvc = "123";
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = model.FirstName;
            buyer.Surname = model.LastName;
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = model.FirstName;
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = "0.3";
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem();
            secondBasketItem.Id = "BI102";
            secondBasketItem.Name = "Game code";
            secondBasketItem.Category1 = "Game";
            secondBasketItem.Category2 = "Online Game Items";
            secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            secondBasketItem.Price = "0.5";
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem();
            thirdBasketItem.Id = "BI103";
            thirdBasketItem.Name = "Usb";
            thirdBasketItem.Category1 = "Electronics";
            thirdBasketItem.Category2 = "Usb / Cable";
            thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            thirdBasketItem.Price = "0.2";
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);
            if(payment.Status == "success")
            {
                System.Console.WriteLine("sa");
            }
            return RedirectToAction("Index","Home");
        }

       

       
    }
}