using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Personal_Account
{
    public partial class SIZContext : DbContext
    {
        public SIZContext()
        {
        }

        public SIZContext(DbContextOptions<SIZContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSnakeCaseNamingConvention();

        public virtual DbSet<AirlineCompany> AirlineCompanies { get; set; } = null!;
        public virtual DbSet<DataAll> DataAlls { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataAll>(entity =>
            {
                entity.HasNoKey();
            });
        
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
