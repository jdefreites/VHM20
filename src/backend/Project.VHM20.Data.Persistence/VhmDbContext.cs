using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Project.VHM20.Data.Entities;
using System.Reflection;

namespace Project.VHM20.Data.Persistence
{
    public class VhmDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public VhmDbContext(DbContextOptions<VhmDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
                return;

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_configuration?.GetConnectionString("DefaultConnection"), providerOptions => providerOptions.CommandTimeout(300))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region DbSet's
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Placa> Placas => Set<Placa>();
        public DbSet<SolicitudPlaca> SolicitudPlacas => Set<SolicitudPlaca>();
        public DbSet<SolicitudPlacaElemento> SolicitudPlacaElementos => Set<SolicitudPlacaElemento>();
        public DbSet<TipoPersona> TiposPersonas => Set<TipoPersona>();
        public DbSet<TipoPlaca> TiposPlacas => Set<TipoPlaca>();
        public DbSet<TipoVehiculo> TiposVehiculos => Set<TipoVehiculo>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();

        #endregion
    }
}