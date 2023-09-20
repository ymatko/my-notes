using Microsoft.EntityFrameworkCore;
using MyNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Sheet> Sheets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sheet>().HasData(
                new Sheet { Id = 1, Name = "1", Text = "One"},
                new Sheet { Id = 2, Name = "2", Text = "Two" },
                new Sheet { Id = 3, Name = "3", Text = "Three" }
                );
        }
    }
}
