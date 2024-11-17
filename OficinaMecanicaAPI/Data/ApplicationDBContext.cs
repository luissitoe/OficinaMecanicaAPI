using Microsoft.EntityFrameworkCore;
using OficinaMecanicaAPI.Models;

namespace OficinaMecanicaAPI.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { 
        
        }

        public DbSet<Cliente> Clientes { get; set; }

    }
}
