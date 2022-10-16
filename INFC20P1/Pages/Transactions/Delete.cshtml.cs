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
    public class DeleteModel : PageModel
    {
        private readonly INFC20P1.Data.INFC20P1TransContext _context;

        public DeleteModel(INFC20P1.Data.INFC20P1TransContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Trans == null)
            {
                return NotFound();
            }
            var trans = await _context.Trans.FindAsync(id);

            if (trans != null)
            {
                Trans = trans;
                _context.Trans.Remove(Trans);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
