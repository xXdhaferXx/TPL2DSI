using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tp2ASP.Data;
using tp2ASP.Models;

namespace tp2ASP.Pages.Taches
{
    public class DeleteModel : PageModel
    {
        private readonly tp2ASP.Data.tp2ASPContext _context;

        public DeleteModel(tp2ASP.Data.tp2ASPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tache tache { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tache = await _context.tache.FirstOrDefaultAsync(m => m.TacheID == id);

            if (tache == null)
            {
                return NotFound();
            }
            else
            {
                tache = tache;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tache = await _context.tache.FindAsync(id);
            if (tache != null)
            {
                tache = tache;
                _context.tache.Remove(tache);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
