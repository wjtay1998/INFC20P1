using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using INFC20P1.Data;
using INFC20P1.Models;
using INFC20P1.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace INFC20P1.Pages
{
    public class AddTModel : PageModel
    {
        private readonly INFC20P1.Data.INFC20P1TransContext _context;

        public string successMessage;

        public string errorMessage;

        public AddTModel(INFC20P1.Data.INFC20P1TransContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TransInput Trans { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // call stored procedure to insert
            System.Diagnostics.Debug.WriteLine("AddT Stored T - " + Trans.tname);

            try
            {
                _context.Database
                    .ExecuteSqlRaw("EXECUTE dbo.CREATE_TRANSACTION {0}, {1}, {2}, {3}, {4}",
                    Trans.tname, Trans.send_pname, Trans.recieve_pname, Trans.t_date, Trans.amount);
            }
            catch (Exception e )
            {
                errorMessage = e.Message;
                return Page();
            }

            successMessage = "Successfully saved Trans of $" + Trans.amount;

            return Page();
        }
    }
}
