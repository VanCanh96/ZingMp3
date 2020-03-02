using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public int VipId { get; set; }
        public bool IsActive { get; set; }

        public Gender Gender { get; set; }
    }
}
