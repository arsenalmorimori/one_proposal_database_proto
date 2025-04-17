﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using one_db_prototype.Data;

#nullable disable

namespace one_db_prototype.Migrations
{
    [DbContext(typeof(one_db_prototypeContext))]
    partial class one_db_prototypeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("one_db_prototype.Model.Club", b =>
                {
                    b.Property<int>("club_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("club_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("club_id");

                    b.ToTable("Club");
                });
#pragma warning restore 612, 618
        }
    }
}
