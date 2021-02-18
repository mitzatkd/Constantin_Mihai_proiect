using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Constantin_Mihai_proiect.Data;
using Constantin_Mihai_proiect.Models;

namespace Constantin_Mihai_proiect.Pages.Companies
{
    public class CreateModel : PageModel
    {
        private readonly Constantin_Mihai_proiect.Data.Constantin_Mihai_proiectContext _context;

        public CreateModel(Constantin_Mihai_proiect.Data.Constantin_Mihai_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductionCo ProductionCo { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductionCo.Add(ProductionCo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
