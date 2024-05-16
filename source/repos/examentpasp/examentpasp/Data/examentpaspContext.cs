using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using examentpasp.Models;

namespace examentpasp.Data
{
    public class examentpaspContext : DbContext
    {
        public examentpaspContext (DbContextOptions<examentpaspContext> options)
            : base(options)
        {
        }

        

        public DbSet<Score> Scores { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>().ToTable("Score");
            
        }
    }
}
