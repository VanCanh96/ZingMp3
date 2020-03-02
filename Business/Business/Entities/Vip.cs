using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Vip : BaseEntity
    {
        public string Name { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
