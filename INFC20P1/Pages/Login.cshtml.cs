using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFC20P1.Models;
using Microsoft.AspNetCore.Http;
using INFC20P1.Data;
using Microsoft.EntityFrameworkCore;

namespace INFC20P1.Pages
{
    public class LoginModel : PageModel
    {
        private readonly INFC20P1PersonContext _personContext;
        public string errorMessage;

        public LoginModel(INFC20P1PersonContext personContext)
        {
            _personContext = personContext;
        }

        [BindProperty]
        public Person user { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogin()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            System.Diagnostics.Debug.WriteLine("Attempting login - " + user.pname);
            var attempt = _personContext.Person
                .FromSqlRaw($"EXECUTE dbo.GET_PERSON_BY_NAME @NAME=\"" + user.pname + "\"")
                .ToList()[0];
            System.Diagnostics.Debug.WriteLine("Attempting login attempt: - " + attempt);
            if (user.pname == null || user.pname.Length == 0 || attempt == null)
            {
                errorMessage = "Invalid Username";

                return Page();
            }
            // Plain Text
            //if(attempt != null && attempt.Password.Equals(user.Password))
            // BCrypt Encryption

            if (attempt != null)
            {
                errorMessage = null;
                HttpContext.Session.SetString("username", attempt.pname);
                System.Diagnostics.Debug.WriteLine("Successful Login - " + attempt.pname);

                return RedirectToPage("/Index");
            }

            errorMessage = "Invalid Username/Password";

            return Page();
        }
    }
}
