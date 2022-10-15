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

            var Trans = await _context.Trans.FirstOrDefaultAsync(m => m.tid == id);

            if (Trans == null)
            {
                return NotFound();
            }
            else 
            {
                Trans = Trans;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Trans == null)
            {
                return NotFound();
            }
            var Trans = await _context.Trans.FindAsync(id);

            if (Trans != null)
            {
                Trans = Trans;
                _context.Trans.Remove(Trans);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
