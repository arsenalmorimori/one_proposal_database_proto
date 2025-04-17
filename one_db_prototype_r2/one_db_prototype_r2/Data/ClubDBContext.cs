using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using one_db_prototype_r2.Model;

namespace one_db_prototype_r2.Data
{
    public class ClubDBContext : DbContext
    {
        public ClubDBContext (DbContextOptions<ClubDBContext> options)
            : base(options)
        {
        }

        public DbSet<one_db_prototype_r2.Model.Club> Club { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // Ensure no migrations are attempted
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseMySql(
                    "DefaultConnection",
                    new MySqlServerVersion(new Version(8, 0, 34)),
                    options => options.EnableRetryOnFailure()
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Explicitly map to your existing table/columns
            modelBuilder.Entity<Club>(entity => {
                entity.ToTable("club_main_tbl");  // Your actual table name
                entity.HasKey(e => e.club_id);  // Primary key
                entity.Property(e => e.club_name).IsRequired();  // Required if column is NOT NULL
            });
        }

        }
}
