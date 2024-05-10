using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tp2ASP.Models;

namespace tp2ASP.Data
{
    public class tp2ASPContext : DbContext
    {
        public tp2ASPContext (DbContextOptions<tp2ASPContext> options)
            : base(options)
        {
        }

        //public DbSet<tp2ASP.Models.tache> tache { get; set; } = default!;
        public DbSet<tache> tache { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<tache>().ToTable("Tache");
        }
    }
}
