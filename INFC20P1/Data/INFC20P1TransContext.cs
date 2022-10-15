using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using INFC20P1.Models;

namespace INFC20P1.Data
{
    public class INFC20P1TransContext : DbContext
    {
        public INFC20P1TransContext (DbContextOptions<INFC20P1TransContext> options)
            : base(options)
        {
        }

        public DbSet<INFC20P1.Models.Trans> Trans { get; set; } = default!;
    }
}
