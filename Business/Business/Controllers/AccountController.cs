using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;
using Business.Models.Account;
using Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([Bind] LoginModel model)
        {
            var isOk = await _accountService.CheckValidAccount(model);
            if (isOk)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}