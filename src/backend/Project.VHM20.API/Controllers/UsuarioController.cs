using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.VHM20.Data.Models;
using Project.VHM20.Data.Persistence.Services;

namespace Project.VHM20.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _usuarioService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Nombre de usuario o contraseña es incorrecta" });

            return Ok(response);
        }
    }
}
