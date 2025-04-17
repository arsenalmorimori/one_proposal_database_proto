using Microsoft.EntityFrameworkCore;
using one_db_prototype.Model;

namespace one_db_prototype.Data {
    public class one_db_prototypeContext : DbContext {
        public one_db_prototypeContext(DbContextOptions<one_db_prototypeContext> options)
            : base(options) {
        }

        public DbSet<Club> Club { get; set; }

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