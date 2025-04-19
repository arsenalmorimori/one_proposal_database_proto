using Microsoft.EntityFrameworkCore;
using one_db_prototype_chilibean.Model;
using System.Diagnostics;

namespace one_db_prototype_chilibean.Data {
    public class SqliteDbContext : DbContext {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options)
            : base(options) {
            // Ensure database is created
            Database.EnsureCreated();

            // Enable SQLite logging
            Debug.WriteLine("SQLite Database initialized");
        }

        // Define all your DbSets to match MySQL structure
        public DbSet<Club> club_main_tbl { get; set; }
        public DbSet<ActivityProfile> activity_profile_tbl { get; set; }
        public DbSet<ActivityBrief> activity_brief_tbl { get; set; }
        public DbSet<ActivityDetail> activity_detail_tbl { get; set; }
        public DbSet<ActivityBudgetPlan> activity_budget_plan_tbl { get; set; }
        public DbSet<ActivityStatus> activity_status_tbl { get; set; }
        public DbSet<RemarksActivity> remarks_activity_tbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                // Fallback connection string if not configured via DI
                optionsBuilder.UseSqlite("Data Source=backup.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Configure SQLite-specific model settings
            modelBuilder.Entity<Club>(entity => {
                entity.ToTable("club_main_tbl");
                entity.HasKey(c => c.club_id);
            });

            modelBuilder.Entity<ActivityProfile>(entity => {
                entity.ToTable("activity_profile_tbl");
                entity.HasKey(a => a.activity_id);
                entity.HasOne(a => a.Club)
                      .WithMany()
                      .HasForeignKey(a => a.club_id);
            });

            modelBuilder.Entity<ActivityBrief>(entity => {
                entity.ToTable("activity_brief_tbl");
                entity.HasKey(a => a.activity_id);
                entity.HasOne(a => a.ActivityProfile)
                      .WithOne(p => p.ActivityBrief)
                      .HasForeignKey<ActivityBrief>(a => a.activity_id);
            });

            modelBuilder.Entity<ActivityDetail>(entity => {
                entity.ToTable("activity_detail_tbl");
                entity.HasKey(a => a.activity_id);
                entity.HasOne(a => a.ActivityProfile)
                      .WithOne(p => p.ActivityDetail)
                      .HasForeignKey<ActivityDetail>(a => a.activity_id);
            });

            modelBuilder.Entity<ActivityBudgetPlan>(entity => {
                entity.ToTable("activity_budget_plan_tbl");
                entity.HasKey(a => a.budget_plan_id);
                entity.Property(a => a.budget_plan_id).ValueGeneratedOnAdd();
                entity.HasOne(a => a.ActivityProfile)
                      .WithMany(p => p.ActivityBudgetPlans)
                      .HasForeignKey(a => a.activity_id);
            });

            modelBuilder.Entity<ActivityStatus>(entity => {
                entity.ToTable("activity_status_tbl");
                entity.HasKey(a => a.activity_id);
                entity.HasOne(a => a.ActivityProfile)
                      .WithOne(p => p.ActivityStatus)
                      .HasForeignKey<ActivityStatus>(a => a.activity_id);
            });

            modelBuilder.Entity<RemarksActivity>(entity => {
                entity.ToTable("remarks_activity_tbl");
                entity.HasKey(a => a.activity_id);
                entity.HasOne(a => a.ActivityProfile)
                      .WithOne(p => p.RemarksActivity)
                      .HasForeignKey<RemarksActivity>(a => a.activity_id);
            });

            // SQLite doesn't support the same column types as MySQL, so we need to configure them
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()) {
                foreach (var property in entityType.GetProperties()) {
                    if (property.ClrType == typeof(decimal))
                    {
                        property.SetColumnType("TEXT"); // SQLite doesn't have decimal type
                    } else if (property.ClrType == typeof(DateTime)) {
                        property.SetColumnType("TEXT"); // Store as ISO8601 strings
                    } else if (property.ClrType == typeof(Guid)) {
                        property.SetColumnType("TEXT"); // Store GUIDs as strings
                    }
                }
            }
        }
    }
}