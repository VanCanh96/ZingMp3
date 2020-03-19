using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Entities;
using Business.Models;
using Business.Models.Account;
using Business.Repository;

namespace Business.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> CheckValidAccount(LoginModel model)
        {
            var entity = new Account
            {
                UserName = model.Username,
                Password = model.Password
            };

            var account = await _accountRepository.GetByAccount(entity);
            return account != null;
        }

        public async Task<Account> GetByUsername(string username)
        {
            return await _accountRepository.GetByUsername(username);
        }
    }
}
