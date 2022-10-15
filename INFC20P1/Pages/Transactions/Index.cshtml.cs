using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using INFC20P1.Data;
using INFC20P1.Models;

namespace INFC20P1.Pages.Transs
{
    public class IndexModel : PageModel
    {
        private readonly INFC20P1.Data.INFC20P1TransContext _context;

        public IndexModel(INFC20P1.Data.INFC20P1TransContext context)
        {
            _context = context;
        }

        public IList<Trans> Trans { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Trans != null)
            {
                Trans = await _context.Trans.ToListAsync();
            }
        }
    }
}
