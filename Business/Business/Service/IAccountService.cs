using Business.Entities;
using Business.Models;
using Business.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IAccountService
    {
        Task<bool> CheckValidAccount(LoginModel model);
        Task<Account> GetByUsername(string username);
    }
}
