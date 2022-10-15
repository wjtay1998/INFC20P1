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
        private readonly INFC20P1.Data.INFC20P1TransactionContext _context;

        public DetailsModel(INFC20P1.Data.INFC20P1TransactionContext context)
        {
            _context = context;
        }

      public Transaction Transaction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Transaction == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FirstOrDefaultAsync(m => m.tid == id);
            if (transaction == null)
            {
                return NotFound();
            }
            else 
            {
                Transaction = transaction;
            }
            return Page();
        }
    }
}
