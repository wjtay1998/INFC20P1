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
    public class SummaryModel : PageModel
    {
        private readonly INFC20P1PersonContext _personContext;
        private readonly INFC20P1TransContext _transContext;
        public string errorMessage;
        public string successMessage;

        public SummaryModel(INFC20P1PersonContext personContext, INFC20P1TransContext TransContext)
        {
            _personContext = personContext;
            _transContext = TransContext;
        }

        [BindProperty]
        public string username { get; set; } = default!;

        [BindProperty]
        public IList<TransInput> recieve_trans { get; set; } = default!;
        [BindProperty]
        public IList<TransInput> send_trans { get; set; } = default!;

        [BindProperty]

        public decimal total_outgoing { get; set; }

        [BindProperty]
        public decimal total_incoming { get; set; }
        [BindProperty]
        public decimal balance { get; set; }


        public async Task<IActionResult> OnGet([FromRoute] string pname=null)
        {
            username = pname;
            recieve_trans = new List<TransInput>();
            send_trans = new List<TransInput>();

            try
            {
                var user = _personContext.Set<Person>().FromSqlRaw("EXECUTE dbo.GET_PERSON_BY_NAME {0}", pname).AsEnumerable().First();
                total_outgoing = user.sent;
                total_incoming = user.recieved;
                recieve_trans = _transContext.Set<TransInput>().FromSqlRaw("EXECUTE dbo.GET_RECIEVE_TRANSACTIONS_BY_NAME {0}", pname).AsEnumerable().ToList();
                send_trans = _transContext.Set<TransInput>().FromSqlRaw("EXECUTE dbo.GET_SEND_TRANSACTIONS_BY_NAME {0}", pname).AsEnumerable().ToList();
                balance = total_incoming - total_outgoing;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;

                return Page();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            System.Diagnostics.Debug.WriteLine("Successfully " + username);
            try
            {
                _transContext.Database.ExecuteSqlRaw("EXECUTE dbo.DELETE_TRANSACTION_BY_TID {0}", id);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;

                return RedirectToPage("/Summary", new { pname = username });
            }

            return RedirectToPage("/Summary", new { pname = username });

        }
    }
}
