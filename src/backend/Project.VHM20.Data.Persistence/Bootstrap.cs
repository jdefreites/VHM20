using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Project.VHM20.Data.Persistence.Helpers;
using Project.VHM20.Data.Persistence.Repository;
using Project.VHM20.Data.Persistence.Repository.Base;
using Project.VHM20.Data.Persistence.Repository.Impl;
using Project.VHM20.Data.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Persistence
{
    public static class Bootstrap
    {
        static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddScoped(typeof(IPlacaRepository), typeof(PlacaRepository));
            services.AddScoped(typeof(ISolicitudPlacaRepository), typeof(SolicitudPlacaRepository));
            services.AddScoped(typeof(ITipoPersonaRepository), typeof(TipoPersonaRepository));
            services.AddScoped(typeof(ITipoPlacaRepository), typeof(TipoPlacaRepository));
            services.AddScoped(typeof(ITipoVehiculoRepository), typeof(TipoVehiculoRepository));
            services.AddScoped(typeof(IVehiculoRepository), typeof(VehiculoRepository));

            services.AddScoped<IUsuarioService, UsuarioService>();
        }
        public static void AddVhmServices(this IServiceCollection services)
        { 
            RegisterServices(services);
        }
    }
}
