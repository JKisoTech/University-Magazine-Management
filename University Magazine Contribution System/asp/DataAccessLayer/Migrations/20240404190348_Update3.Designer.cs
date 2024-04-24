﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(UniMagDbContext))]
    [Migration("20240404190348_Update3")]
    partial class Update3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccessLayer.Models.Comment", b =>
                {
                    b.Property<int>("CoordinatorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoordinatorID"));

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContributionID")
                        .HasColumnType("int");

                    b.Property<string>("ContributionID1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CoordinatorID");

                    b.HasIndex("ContributionID1");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Contribution", b =>
                {
                    b.Property<string>("ContributionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AgreeOnTerm")
                        .HasColumnType("bit");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Expired")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ContributionID");

                    b.HasIndex("StudentID");

                    b.ToTable("Contributions", (string)null);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Faculty", b =>
                {
                    b.Property<string>("FacultyID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultyID");

                    b.ToTable("faculty");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Student", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phones")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("DataAccessLayer.Models.SystemParameter", b =>
                {
                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParameterID")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SystemParameters", (string)null);
                });

            modelBuilder.Entity("DataAccessLayer.Models.User", b =>
                {
                    b.Property<string>("LoginName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FacultyID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("LoginName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccessLayer.Models.User_Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FacultyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("LoginName");

                    b.ToTable("user_Faculties");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Comment", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Contribution", null)
                        .WithMany("Comments")
                        .HasForeignKey("ContributionID1");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Contribution", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Student", null)
                        .WithMany("Contributions")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.User_Faculty", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Faculty", "faculty")
                        .WithMany("user_Faculties")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.User", "user")
                        .WithMany("user_Faculties")
                        .HasForeignKey("LoginName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("faculty");

                    b.Navigation("user");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Contribution", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Faculty", b =>
                {
                    b.Navigation("user_Faculties");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Student", b =>
                {
                    b.Navigation("Contributions");
                });

            modelBuilder.Entity("DataAccessLayer.Models.User", b =>
                {
                    b.Navigation("user_Faculties");
                });
#pragma warning restore 612, 618
        }
    }
}
