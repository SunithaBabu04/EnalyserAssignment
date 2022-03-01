using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EnalyserAssignment.DAL.Models
{
    public partial class EnalyserATMContext : DbContext
    {
        public EnalyserATMContext()
        {
        }


        public EnalyserATMContext(DbContextOptions<EnalyserATMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notes> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
