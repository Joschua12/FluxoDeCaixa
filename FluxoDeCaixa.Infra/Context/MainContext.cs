using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FluxoDeCaixa.Infra.Context
{
    public class MainContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MainContext(DbContextOptions<MainContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public MainContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
