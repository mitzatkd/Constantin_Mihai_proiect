using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Constantin_Mihai_proiect.Data;
using Constantin_Mihai_proiect.Models;

namespace Constantin_Mihai_proiect.Pages.Developers
{
    public class DeleteModel : PageModel
    {
        private readonly Constantin_Mihai_proiect.Data.Constantin_Mihai_proiectContext _context;

        public DeleteModel(Constantin_Mihai_proiect.Data.Constantin_Mihai_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Developer Developer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Developer = await _context.Developer.FirstOrDefaultAsync(m => m.ID == id);

            if (Developer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Developer = await _context.Developer.FindAsync(id);

            if (Developer != null)
            {
                _context.Developer.Remove(Developer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
