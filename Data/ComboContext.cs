using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoL1Shot.Models;
using System.Data;

namespace LoL1Shot.Data
{
    public class ComboContext : DbContext
    {
        public ComboContext(DbContextOptions<ComboContext> options) : base(options)
        {
        }
        public DbSet<Combo> Combo { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Combo>().ToTable("Combo");
            modelBuilder.Entity<Combo>();
        }

    }
}
