using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using INFC20P1.Models;

namespace INFC20P1.Data
{
    public class INFC20P1PersonContext : DbContext
    {
        public INFC20P1PersonContext (DbContextOptions<INFC20P1PersonContext> options)
            : base(options)
        {
        }

        public DbSet<INFC20P1.Models.Person> Person { get; set; } = default!;
    }
}
