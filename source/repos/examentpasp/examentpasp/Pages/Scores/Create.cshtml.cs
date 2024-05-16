using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using examentpasp.Data;
using examentpasp.Models;

namespace examentpasp.Pages.Scores
{
    public class CreateModel : PageModel
    {
        private readonly examentpasp.Data.examentpaspContext _context;

        public CreateModel(examentpasp.Data.examentpaspContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Score Score { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Scores.Add(Score);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
