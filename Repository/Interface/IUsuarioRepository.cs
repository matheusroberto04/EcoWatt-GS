using EcoWatt.Dtos;
using EcoWatt.Models;

namespace EcoWatt.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int usuarioId);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<Usuario> Login (LoginDto usuario);
        Task<Usuario> Register (Usuario usuario);
        void DeleteUsuario(int usuarioId);
    }
}
