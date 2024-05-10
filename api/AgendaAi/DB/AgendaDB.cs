using Microsoft.EntityFrameworkCore;
using AgendaAi.Models;

namespace AgendaAi.DB
{
    public class AgendaDB : DbContext
    {
        public AgendaDB(DbContextOptions<AgendaDB> options) : base(options) { }

        public DbSet<LegalPerson> LegalPersons => Set<LegalPerson>();
        public DbSet<NaturalPerson> NaturalPersons => Set<NaturalPerson>();
        public DbSet<SuperAdmin> SuperAdmins => Set<SuperAdmin>();
    }
}
