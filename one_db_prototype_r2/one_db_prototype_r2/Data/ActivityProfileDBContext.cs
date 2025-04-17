// ActivityProfileDBContext.cs
using Microsoft.EntityFrameworkCore;
using one_db_prototype_r2.Model;

public class ActivityProfileDBContext : DbContext {
    public ActivityProfileDBContext(DbContextOptions<ActivityProfileDBContext> options) : base(options) { }

    public DbSet<ActivityProfile> ActivityProfile { get; set; }
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
        modelBuilder.Entity<ActivityProfile>(entity => {
            entity.ToTable("activity_profile_tbl");
            entity.HasKey(e => e.activity_id);

            entity.Property(e => e.club_id)
                .IsRequired()
                .HasColumnName("club_id");

            entity.Property(e => e.activity_title)
                .IsRequired()
                .HasColumnName("activity_title")
                .HasMaxLength(100);

            entity.Property(e => e.activity_date)
                .IsRequired()
                .HasColumnName("activity_date")
                .HasColumnType("datetime");
        });
    }
}