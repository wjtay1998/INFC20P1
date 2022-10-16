using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INFC20P1.Data;
using INFC20P1.Models;

namespace INFC20P1.Pages.Transactions
{
    public class EditModel : PageModel
    {
        private readonly INFC20P1.Data.INFC20P1TransContext _context;

        public EditModel(INFC20P1.Data.INFC20P1TransContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trans Trans { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Trans == null)
            {
                return NotFound();
            }

            var trans =  await _context.Trans.FirstOrDefaultAsync(m => m.tid == id);
            if (trans == null)
            {
                return NotFound();
            }
            Trans = trans;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Trans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransExists(Trans.tid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TransExists(int id)
        {
          return _context.Trans.Any(e => e.tid == id);
        }
    }
}
