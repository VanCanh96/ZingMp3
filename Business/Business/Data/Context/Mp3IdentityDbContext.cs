using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Data.Context
{
    public class Mp3IdentityDbContext : IdentityDbContext
    {
        public Mp3IdentityDbContext(DbContextOptions<Mp3IdentityDbContext> options)
            : base(options)
        {
        }
    }
}
