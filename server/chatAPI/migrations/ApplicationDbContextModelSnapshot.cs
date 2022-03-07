﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using chatAPI.Data;

#nullable disable

namespace chatAPI.migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("chatAPI.Models.Role", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"), 1L, 1);

                    b.Property<string>("RoleName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = (short)-1,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("chatAPI.Models.Status", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("ID"), 1L, 1);

                    b.Property<string>("NormalizedStatusName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StatusName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("ID");

                    b.HasIndex("NormalizedStatusName");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            ID = (short)-1,
                            NormalizedStatusName = "ON BREAK",
                            StatusName = "ON BREAK"
                        },
                        new
                        {
                            ID = (short)-2,
                            NormalizedStatusName = "ON CALL",
                            StatusName = "ON CALL"
                        },
                        new
                        {
                            ID = (short)-3,
                            NormalizedStatusName = "IN MEETING",
                            StatusName = "IN MEETING"
                        });
                });

            modelBuilder.Entity("chatAPI.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirht")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("LastStatusChange")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedUsername")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<short?>("RoleID")
                        .HasColumnType("smallint");

                    b.Property<short?>("StatusID")
                        .HasColumnType("smallint");

                    b.Property<string>("Username")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ID");

                    b.HasIndex("NormalizedUsername");

                    b.HasIndex("RoleID");

                    b.HasIndex("StatusID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("chatAPI.Models.User", b =>
                {
                    b.HasOne("chatAPI.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID");

                    b.HasOne("chatAPI.Models.Status", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusID");

                    b.Navigation("Role");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("chatAPI.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("chatAPI.Models.Status", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
