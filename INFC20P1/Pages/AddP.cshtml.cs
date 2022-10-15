using INFC20P1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace INFC20P1.Pages
{
    public class AddPModel : PageModel
    {
        private readonly INFC20P1.Data.INFC20P1PersonContext _context;

        public string successMessage;

        public AddPModel(INFC20P1.Data.INFC20P1PersonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // call stored procedure to insert
            System.Diagnostics.Debug.WriteLine("AddP Stored P - " + Person.pname);


            var result = _context.Person.FromSqlRaw("EXECUTE dbo.CREATE_PERSON {0}", Person.pname);

            
            System.Diagnostics.Debug.WriteLine("AddP Stored P - " + result.ToString());


            successMessage = "Successfully added " + Person.pname;

            return Page();
        }
    }
}
