using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFC20P1.Models;
using Microsoft.AspNetCore.Http;
using INFC20P1.Data;
using INFC20P1.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace INFC20P1.Pages
{
    public class EditPModel : PageModel
    {

        public string errorMessage;
        public string successMessage;
        private readonly INFC20P1.Data.INFC20P1TransContext _context;

        public EditPModel(INFC20P1.Data.INFC20P1TransContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TransInput Trans { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            try
            {
                Trans = _context.Set<TransInput>().FromSqlRaw("EXECUTE dbo.GET_TRANSACTIONS_BY_TID {0}", id).AsEnumerable().FirstOrDefault();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;

                return Page();
            }

            Trans = Trans;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            errorMessage = null;
            successMessage = null;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Database
                    .ExecuteSqlRaw("EXECUTE dbo.UPDATE_TRANSACTION {0}, {1}, {2}, {3}, {4}, {5}",
                    Trans.tid, Trans.tname, Trans.send_pname, Trans.recieve_pname, Trans.amount, Trans.t_date);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return Page();
            }

            System.Diagnostics.Debug.WriteLine("Successfully edited T");

            successMessage = "Successfully updated " + Trans.tname;

            return Page();

        }

        

    }
}
