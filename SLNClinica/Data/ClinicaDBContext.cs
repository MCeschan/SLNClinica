using Microsoft.EntityFrameworkCore;
using SLNClinica.Models;

namespace SLNClinica.Data
{
    public class ClinicaDBContext : DbContext
    {
        public ClinicaDBContext(DbContextOptions<ClinicaDBContext> options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }
    }
}
