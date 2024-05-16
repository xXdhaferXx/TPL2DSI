using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using examentpasp.Data;
using examentpasp.Models;

namespace examentpasp.Pages.Scores
{
    public class IndexModel : PageModel
    {
        private readonly examentpasp.Data.examentpaspContext _context;

        public IndexModel(examentpasp.Data.examentpaspContext context)
        {
            _context = context;
        }

        public IList<Score> Score { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Score = await _context.Scores.ToListAsync();
        }
    }
}
