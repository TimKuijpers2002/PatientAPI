using Microsoft.EntityFrameworkCore;
using PatientAPI.Models;

namespace PatientAPI.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {
            
        }

        public DbSet<Patient> Patients => Set<Patient>();
    }
}
