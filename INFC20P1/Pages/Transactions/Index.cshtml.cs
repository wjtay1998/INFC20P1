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
    public class IndexModel : PageModel
    {
        private readonly INFC20P1.Data.INFC20P1TransactionContext _context;

        public IndexModel(INFC20P1.Data.INFC20P1TransactionContext context)
        {
            _context = context;
        }

        public IList<Transaction> Transaction { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Transaction != null)
            {
                Transaction = await _context.Transaction.ToListAsync();
            }
        }
    }
}
