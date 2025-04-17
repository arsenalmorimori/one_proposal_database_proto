using Microsoft.EntityFrameworkCore;
using one_db_prototype_r2.Model;

namespace one_db_prototype_r2.Data {
    public class AppDBContext : DbContext {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<ActivityProfile> ActivityProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Club entity
            modelBuilder.Entity<Club>(entity => {
                entity.ToTable("club_main_tbl");
                entity.HasKey(e => e.club_id);

                entity.Property(e => e.club_name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            // ActivityProfile entity
            modelBuilder.Entity<ActivityProfile>(entity => {
                entity.ToTable("activity_profile_tbl");
                entity.HasKey(e => e.activity_id);

                entity.Property(e => e.club_id)
                    .IsRequired();

                entity.Property(e => e.activity_title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.activity_date)
                    .IsRequired()
                    .HasColumnType("datetime");

                // Define relationship
                entity.HasOne<Club>()
                      .WithMany()
                      .HasForeignKey(e => e.club_id)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}