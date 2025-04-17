using Microsoft.EntityFrameworkCore;
using one_db_prototype_chilibean.Model;
using System;

namespace one_db_prototype_chilibean.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public DbSet<Club> club_main_tbl { get; set; }
        public DbSet<ActivityProfile> activity_profile_tbl { get; set; }
        public DbSet<ActivityBrief> activity_brief_tbl { get; set; }
        public DbSet<ActivityDetail> activity_detail_tbl { get; set; }
        public DbSet<ActivityBudgetPlan> activity_budget_plan_tbl { get; set; }
        public DbSet<ActivityStatus> activity_status_tbl { get; set; }
        public DbSet<RemarksActivity> remarks_activity_tbl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Configure Club table
            modelBuilder.Entity<Club>(entity => {
                entity.ToTable("club_main_tbl");
                entity.HasKey(e => e.club_id);
                entity.Property(e => e.club_name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            // Configure ActivityProfile table
            modelBuilder.Entity<ActivityProfile>(entity => {
                entity.ToTable("activity_profile_tbl");
                entity.HasKey(e => e.activity_id);

                entity.Property(e => e.activity_id)
                    .HasDefaultValueSql("UUID()");

                entity.Property(e => e.activity_title)
                    .IsRequired()
                    .HasMaxLength(150);


                entity.HasOne(a => a.Club)
                    .WithMany(c => c.ActivityProfiles)
                    .HasForeignKey(a => a.club_id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure ActivityBrief table
            modelBuilder.Entity<ActivityBrief>(entity => {
                entity.ToTable("activity_brief_tbl");
                entity.HasKey(e => e.activity_id);

                entity.Property(e => e.activity_brief_description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.activity_date)
                    .IsRequired();

                entity.HasOne(ab => ab.ActivityProfile)
                    .WithOne(ap => ap.ActivityBrief)
                    .HasForeignKey<ActivityBrief>(ab => ab.activity_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure ActivityDetail table
            modelBuilder.Entity<ActivityDetail>(entity => {
                entity.ToTable("activity_detail_tbl");
                entity.HasKey(e => e.activity_id);

                entity.Property(e => e.activity_rationale)
                    .IsRequired()
                    .HasMaxLength(5000);

                entity.Property(e => e.activity_objectives)
                    .IsRequired()
                    .HasMaxLength(5000);

                entity.Property(e => e.activity_activity_type)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.activity_activity_reach)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(ad => ad.ActivityProfile)
                    .WithOne(ap => ap.ActivityDetail)
                    .HasForeignKey<ActivityDetail>(ad => ad.activity_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure ActivityBudgetPlan table
            modelBuilder.Entity<ActivityBudgetPlan>(entity => {
                entity.ToTable("activity_budget_plan_tbl");
                entity.HasKey(e => e.budget_plan_id);

                entity.Property(e => e.item_name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.price)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.quantity)
                    .IsRequired();

                entity.HasOne(abp => abp.ActivityProfile)
                    .WithMany(ap => ap.ActivityBudgetPlans)
                    .HasForeignKey(abp => abp.activity_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure ActivityStatus table
            modelBuilder.Entity<ActivityStatus>(entity => {
                entity.ToTable("activity_status_tbl");
                entity.HasKey(e => e.activity_id);

                entity.Property(e => e.activity_overall_status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("pending");

                entity.Property(e => e.admin_1_status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("pending");

                entity.Property(e => e.admin_2_status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("pending");

                entity.Property(e => e.admin_3_status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("pending");

                entity.Property(e => e.checked_date)
                    .IsRequired();

                entity.HasOne(ast => ast.ActivityProfile)
                    .WithOne(ap => ap.ActivityStatus)
                    .HasForeignKey<ActivityStatus>(ast => ast.activity_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure RemarksActivity table
            modelBuilder.Entity<RemarksActivity>(entity => {
                entity.ToTable("remarks_activity_tbl");
                entity.HasKey(e => e.activity_id);

                entity.Property(e => e.activity_title_remark)
                    .HasMaxLength(1000);

                entity.Property(e => e.activity_brief_description_remark)
                    .HasMaxLength(1000);

                entity.Property(e => e.rationale_remark)
                    .HasMaxLength(1000);

                entity.Property(e => e.objectives_remark)
                    .HasMaxLength(1000);

                entity.Property(e => e.activity_type_remark)
                    .HasMaxLength(1000);

                entity.Property(e => e.activity_date_remark)
                    .HasMaxLength(1000);

                entity.Property(e => e.activity_reach_remark)
                    .HasMaxLength(1000);

                entity.Property(e => e.activity_budget_remark)
                    .HasMaxLength(1000);

                entity.HasOne(ra => ra.ActivityProfile)
                    .WithOne(ap => ap.RemarksActivity)
                    .HasForeignKey<RemarksActivity>(ra => ra.activity_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}