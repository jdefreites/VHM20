using Project.VHM20.Data.Entities;
using Project.VHM20.Data.Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Persistence
{
    internal static class InitDbData
    {
        public static List<TipoPersona> TipoPersonasData =>
            new()
            {
                new() { Id = 1, Descripcion = "Persona Física"},
                new() { Id = 2, Descripcion = "Persona Jurídica"}
            };

        public static List<TipoPlaca> TipoPlacasData =>
            new()
            {
                new() { Id = 1, Descripcion = "Placas Corrientes"},
                new() { Id = 2, Descripcion = "Placas exoneradas"}
            };

        public static List<TipoVehiculo> TipoVehiculosData =>
            new()
            {
                new() { Id = 1, Descripcion = "Publico", Letra = "A", TipoPlacaId = 1, Valor = 2500m},
                new() { Id = 2, Descripcion = "Privado", Letra = "F", TipoPlacaId = 1, Valor = 3500m},
                new() { Id = 3, Descripcion = "Transporte", Letra = "T", TipoPlacaId = 1, Valor = 2500m},
                new() { Id = 4, Descripcion = "Pesado", Letra = "P", TipoPlacaId = 1, Valor = 5500m}
            };

        public static List<Cliente> ClientesData =>
            new()
            {
                new() { Id = 1, Nombre = "Pedro", Apellido = "Perez", FechaNacimiento = new DateTime(2000, 5, 18), DocumentoIdentidad = "00100000012"},
                new() { Id = 2, Nombre = "Jason", Apellido = "De Freites", FechaNacimiento = new DateTime(1980, 8, 26), DocumentoIdentidad = "02301074528"}
            };

        public static List<Usuario> UsuariosData
        {
            get
            {
                var password = Hash.HashPassword("Password1", out var stamp);
                return new()
                {
                    new() { Id = 1, NombreUsuario = "admin", Contrasena = password, Sello = Convert.ToHexString(stamp)}
                };
            }
        }
    }
}
