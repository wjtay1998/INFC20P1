using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using INFC20P1.Data;
using INFC20P1.Models;

namespace INFC20P1.Pages.Transactions
{
    public class DetailsModel : PageModel
    {
        private readonly INFC20P1.Data.INFC20P1TransContext _context;

        public DetailsModel(INFC20P1.Data.INFC20P1TransContext context)
        {
            _context = context;
        }

      public Trans Trans { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Trans == null)
            {
                return NotFound();
            }

            var trans = await _context.Trans.FirstOrDefaultAsync(m => m.tid == id);
            if (trans == null)
            {
                return NotFound();
            }
            else 
            {
                Trans = trans;
            }
            return Page();
        }
    }
}
