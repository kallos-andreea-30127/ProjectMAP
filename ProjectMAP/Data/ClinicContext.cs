using Microsoft.EntityFrameworkCore;
using ProjectMAP.Models;

namespace ProjectMAP.Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }

        public DbSet<Diagnostic> Diagnostics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalImage> MedicalImages { get; set; }
        public DbSet<Pacient> Pacients { get; set;}
        public DbSet<Specialty> Specialtys { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnostic>().ToTable("Diagnostic");
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<MedicalImage>().ToTable("MedicalImage");
            modelBuilder.Entity<Pacient>().ToTable("Pacient");
            modelBuilder.Entity<Specialty>().ToTable("Specialty");
        }
    }

}
