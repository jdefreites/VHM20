using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project.VHM20.Data.Entities;
using Project.VHM20.Data.Models;
using Project.VHM20.Data.Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.VHM20.Data.Persistence.Services
{
    public class UsuarioService : IUsuarioService
    {
        readonly VhmDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;

        public UsuarioService(VhmDbContext context, IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _configuration = configuration;
            _jwtSettings = jwtSettings.Value;
        }

        public AuthenticateResponse? Authenticate(AuthenticateRequest model)
        {
            var usuario = _context.Usuarios.FirstOrDefault(p=>p.NombreUsuario == model.NombreUsuario);
            if (usuario == null) return null;

            if(!Hash.VerifyPassword(model.Contrasena, usuario.Contrasena, Convert.FromHexString(usuario.Sello))) return null;

            var token = GenerateJwtToken(usuario);

            return new AuthenticateResponse
            {
                Id = usuario.Id,
                NombreUsuario = usuario.NombreUsuario,
                Token = token
            };
        }

        public IEnumerable<Usuario> GetAll() => _context.Usuarios.ToList();

        public Usuario? GetById(int id) => _context.Usuarios.FirstOrDefault(p=>p.Id == id);
        

        private string GenerateJwtToken(Usuario user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim("id", user.Id.ToString()),
                    new Claim("userName", user.NombreUsuario)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
