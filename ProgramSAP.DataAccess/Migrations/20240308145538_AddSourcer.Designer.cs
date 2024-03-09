﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgramSAP.DataAccess;

#nullable disable

namespace ProgramSAP.DataAccess.Migrations
{
    [DbContext(typeof(RecruitingProgramContext))]
    [Migration("20240308145538_AddSourcer")]
    partial class AddSourcer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProgramSAP.DataAccess.Entities.Recruiter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recruiters");
                });

            modelBuilder.Entity("ProgramSAP.DataAccess.Entities.Requisition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("JobLevel")
                        .HasColumnType("int");

                    b.Property<int>("RecruiterId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("RecruiterId");

                    b.ToTable("Requisitions");
                });

            modelBuilder.Entity("ProgramSAP.DataAccess.Entities.Sourcer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaOfExpertise")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("SeniorityLevel")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Sourcers");
                });

            modelBuilder.Entity("RequisitionSourcer", b =>
                {
                    b.Property<int>("RequisitionId")
                        .HasColumnType("int");

                    b.Property<int>("SourcersId")
                        .HasColumnType("int");

                    b.HasKey("RequisitionId", "SourcersId");

                    b.HasIndex("SourcersId");

                    b.ToTable("RequisitionSourcer");
                });

            modelBuilder.Entity("ProgramSAP.DataAccess.Entities.Requisition", b =>
                {
                    b.HasOne("ProgramSAP.DataAccess.Entities.Recruiter", "Recruiter")
                        .WithMany("Requisitions")
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recruiter");
                });

            modelBuilder.Entity("RequisitionSourcer", b =>
                {
                    b.HasOne("ProgramSAP.DataAccess.Entities.Requisition", null)
                        .WithMany()
                        .HasForeignKey("RequisitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgramSAP.DataAccess.Entities.Sourcer", null)
                        .WithMany()
                        .HasForeignKey("SourcersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgramSAP.DataAccess.Entities.Recruiter", b =>
                {
                    b.Navigation("Requisitions");
                });
#pragma warning restore 612, 618
        }
    }
}