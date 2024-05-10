using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tp2ASP.Data;
using tp2ASP.Models;

namespace tp2ASP.Pages.Taches
{
    public class CreateModel : PageModel
    {
        private readonly tp2ASP.Data.tp2ASPContext _context;

        public CreateModel(tp2ASP.Data.tp2ASPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public tache tache { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tache.Add(tache);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
