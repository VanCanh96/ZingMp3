using Business.Entities;
using System.Threading.Tasks;

namespace Business.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetByAccount(Account account);
    }
}
