using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Infrastructure;
using Business.Models;
using Business.Models.Account;
using Business.Service;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;

namespace Business.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailService _emailService;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // 1
                //if (await _accountService.CheckValidAccount(model))
                //{
                //    var user = await _accountService.GetByUsername(model.Username);
                //    //var isuser = new IdentityServerUser(user.Id.ToString())
                //    //{
                //    //    DisplayName = user.UserName
                //    //};

                //    var claims = new List<Claim>
                //    {
                //        new Claim(ClaimTypes.Name, user.UserName)
                //    };

                //    var id = new ClaimsIdentity(claims, "identity");
                //    await HttpContext.SignInAsync(new ClaimsPrincipal(id));

                //    return Redirect("/Home/Index");
                //}

                //2
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect("/");
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Username,
                    Email = "avancanh@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 5
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var link = Url.Action(nameof(VerifyEmail), "Account", new { userId = user.Id, code }, Request.Scheme, Request.Host.ToString());
                    await _emailService.SendAsync("avancanh@gmail.com", "email verify", $"<a href=\"{link}\"></a>");

                    return RedirectToAction("EmailVerification");
                }
            }

            return Redirect("/");
        }

        public IActionResult EmailVerification() => View();

        public async Task<IActionResult> VerifyEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return View();
            }

            return BadRequest();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}