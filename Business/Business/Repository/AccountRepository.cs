using Business.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Mp3DbContext _context;

        public AccountRepository(Mp3DbContext context)
        {
            _context = context;
        }

        public async Task<Account> GetByAccount(Account account)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.UserName == account.UserName && x.Password == account.Password && x.IsActive);
        }

        public async Task<Account> GetByUsername(string username)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.UserName == username && x.IsActive);
        }
    }
}
