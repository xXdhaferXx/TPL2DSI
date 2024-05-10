using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp2ASP.Data;
using tp2ASP.Models;

namespace tp2ASP.Pages.Taches
{
    public class EditModel : PageModel
    {
        private readonly tp2ASP.Data.tp2ASPContext _context;

        public EditModel(tp2ASP.Data.tp2ASPContext context)
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

            var tache =  await _context.tache.FirstOrDefaultAsync(m => m.TacheID == id);
            if (tache == null)
            {
                return NotFound();
            }
            tache = tache;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(tache).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tacheExists(tache.TacheID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool tacheExists(int id)
        {
            return _context.tache.Any(e => e.TacheID == id);
        }
    }
}
