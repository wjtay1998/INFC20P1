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
    public class MainModel : PageModel
    {
        private readonly INFC20P1PersonContext _personContext;
        private readonly INFC20P1TransContext _TransContext;
        public string errorMessage;

        public MainModel(INFC20P1PersonContext personContext, INFC20P1TransContext TransContext)
        {
            _personContext = personContext;
            _TransContext = TransContext;
        }

        [BindProperty]
        public Person user { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSearch()
        {

            return RedirectToPage("/Summary", new { pname = user.pname });
        }
    }
}
