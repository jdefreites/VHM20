using Project.VHM20.Data.Entities;
using Project.VHM20.Data.Models;

namespace Project.VHM20.Data.Persistence.Services
{
    public interface IUsuarioService
    {
        AuthenticateResponse? Authenticate(AuthenticateRequest model);
        IEnumerable<Usuario> GetAll();
        Usuario? GetById(int id);
    }
}
