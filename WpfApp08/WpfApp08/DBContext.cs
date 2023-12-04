using WpfApp08.Models3;
using WpfApp08.Models2;
using WPF_Salaries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace WpfApp08
{
    public class AnnuaireContext : DbContext
    {
        public AnnuaireContext(DbContextOptions<AnnuaireContext> options)
            : base(options)
        {

        }

        public DbSet<Salaries> Salaries { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Sites> Sites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=Annuaire;Trusted_Connection=True;TrustServerCertificate=true;");
            }

        }
    }
}
