﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectMAP.Data;

#nullable disable

namespace ProjectMAP.Migrations
{
    [DbContext(typeof(ClinicContext))]
    partial class ClinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectMAP.Models.Diagnostic", b =>
                {
                    b.Property<int>("DiagnosticID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiagnosticID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiagnosticName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiagnosticID");

                    b.ToTable("Diagnostic", (string)null);
                });

            modelBuilder.Entity("ProjectMAP.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorID"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecialtyID")
                        .HasColumnType("int");

                    b.HasKey("DoctorID");

                    b.HasIndex("SpecialtyID");

                    b.ToTable("Doctor", (string)null);
                });

            modelBuilder.Entity("ProjectMAP.Models.MedicalImage", b =>
                {
                    b.Property<int>("MedicalImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicalImageID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiagnosticID")
                        .HasColumnType("int");

                    b.Property<int?>("DoctorID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("PacientID")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicalImageID");

                    b.HasIndex("DiagnosticID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PacientID");

                    b.ToTable("MedicalImage", (string)null);
                });

            modelBuilder.Entity("ProjectMAP.Models.Pacient", b =>
                {
                    b.Property<int>("PacientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacientID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInsured")
                        .HasColumnType("bit");

                    b.Property<string>("PacientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PacientID");

                    b.ToTable("Pacient", (string)null);
                });

            modelBuilder.Entity("ProjectMAP.Models.Specialty", b =>
                {
                    b.Property<int>("SpecialtyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecialtyID"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialtyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecialtyID");

                    b.ToTable("Specialty", (string)null);
                });

            modelBuilder.Entity("ProjectMAP.Models.Doctor", b =>
                {
                    b.HasOne("ProjectMAP.Models.Specialty", "Specialty")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecialtyID");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("ProjectMAP.Models.MedicalImage", b =>
                {
                    b.HasOne("ProjectMAP.Models.Diagnostic", "Diagnostic")
                        .WithMany("MedicalImages")
                        .HasForeignKey("DiagnosticID");

                    b.HasOne("ProjectMAP.Models.Doctor", "Doctor")
                        .WithMany("MedicalImages")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectMAP.Models.Pacient", "Pacient")
                        .WithMany("MedicalImages")
                        .HasForeignKey("PacientID");

                    b.Navigation("Diagnostic");

                    b.Navigation("Doctor");

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("ProjectMAP.Models.Diagnostic", b =>
                {
                    b.Navigation("MedicalImages");
                });

            modelBuilder.Entity("ProjectMAP.Models.Doctor", b =>
                {
                    b.Navigation("MedicalImages");
                });

            modelBuilder.Entity("ProjectMAP.Models.Pacient", b =>
                {
                    b.Navigation("MedicalImages");
                });

            modelBuilder.Entity("ProjectMAP.Models.Specialty", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
