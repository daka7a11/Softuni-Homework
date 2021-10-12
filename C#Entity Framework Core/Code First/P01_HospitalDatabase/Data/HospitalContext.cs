
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }
        public HospitalContext(DbContextOptions<HospitalContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Diagnose> Diagnoses { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=Hospital;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(x => x.PatientId);

                entity.Property(p => p.FirstName)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);

                entity.Property(p => p.LastName)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);

                entity.Property(p => p.Address)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(250);

                entity.Property(p => p.Email)
                      .IsRequired()
                      .IsUnicode(false)
                      .HasMaxLength(80);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(x => x.VisitationId);

                entity.Property(v => v.Comments)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(250);

                entity.HasOne(v => v.Patient)
                      .WithMany(p => p.Visitations)
                      .HasForeignKey(v => v.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(x => x.DiagnoseId);

                entity.Property(d => d.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);

                entity.Property(d => d.Comments)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(250);

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.Diagnoses)
                      .HasForeignKey(d => d.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(x => x.MedicamentId);

                entity.Property(m => m.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(x => new { x.PatientId, x.MedicamentId });

                entity.HasOne(pm => pm.Patient)
                      .WithMany(p => p.Prescriptions)
                      .HasForeignKey(pm => pm.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pm => pm.Medicament)
                     .WithMany(m => m.Prescriptions)
                     .HasForeignKey(pm => pm.MedicamentId)
                     .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(x => x.DoctorId);

                entity.Property(d => d.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);

                entity.Property(d => d.Speciality)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);
            });
        }
    }
}
