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
    public class SummaryModel : PageModel
    {
        private readonly INFC20P1PersonContext _personContext;
        private readonly INFC20P1TransContext _TransContext;
        public string errorMessage;

        public SummaryModel(INFC20P1PersonContext personContext, INFC20P1TransContext TransContext)
        {
            _personContext = personContext;
            _TransContext = TransContext;
        }

        [BindProperty]
        public string username { get; set; } = default!;

        [BindProperty]
        public IList<Trans> trans { get; set; } = default!;

        [BindProperty]

        public decimal total_outgoing { get; set; }

        [BindProperty]
        public decimal total_incoming { get; set; }
        [BindProperty]
        public decimal balance { get; set; }


        public void OnGet([FromRoute] string pname=null)
        {
            username = pname;
            trans = new List<Trans>();
        }
    }
}
