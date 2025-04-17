// ClubDBContext.cs
using Microsoft.EntityFrameworkCore;
using one_db_prototype_r2.Model;

public class ClubDBContext : DbContext {
    public ClubDBContext(DbContextOptions<ClubDBContext> options) : base(options) { }

    public DbSet<Club> Club { get; set; }
    // Add this method INSIDE the class
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseMySql(
                "DefaultConnection",
                new MySqlServerVersion(new Version(8, 0, 34)),
                options => options
                    .EnableRetryOnFailure()
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery) // Optional
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Club>(entity => {
            entity.ToTable("club_main_tbl");
            entity.HasKey(e => e.club_id);
            entity.Property(e => e.club_name)
                .IsRequired()
                .HasColumnName("club_name") // Explicit column mapping
                .HasMaxLength(255); // Match your DB schema
        });
    }
}