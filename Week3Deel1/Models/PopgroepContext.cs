using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Deel1.Models
{
    class PopgroepContext : DbContext
    {
        public DbSet<Popgroep> Popgroepen { get; set; }
        public DbSet<Artiest> Artiesten { get; set; }
        public DbSet<Instrument> Instrumenten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Week3Deel1;Trusted_Connection=True;");
        }
    }
}
