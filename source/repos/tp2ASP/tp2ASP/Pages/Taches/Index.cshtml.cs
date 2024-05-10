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
    public class IndexModel : PageModel
    {
        private readonly tp2ASP.Data.tp2ASPContext _context;

        public IndexModel(tp2ASP.Data.tp2ASPContext context)
        {
            _context = context;
        }

        public IList<tache> tache { get;set; } = default!;

        public async Task OnGetAsync()
        {
            tache = await _context.tache.ToListAsync();
        }
    }
}
