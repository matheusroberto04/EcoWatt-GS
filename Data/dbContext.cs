using EcoWatt.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoWatt.Data
{
    public class dbContext : DbContext 
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Eletrodomesticos> Eletrodomesticos { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
    }
}
