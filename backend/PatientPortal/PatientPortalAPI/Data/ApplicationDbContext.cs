using Microsoft.EntityFrameworkCore;
using PatientPortalAPI.Models;

namespace PatientPortalAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<LabResult> LabResults { get; set; }

        public DbSet<Vitals> Vitals { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
    }
}
