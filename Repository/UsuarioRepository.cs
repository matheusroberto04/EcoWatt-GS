using EcoWatt.Data;
using EcoWatt.Dtos;
using EcoWatt.Models;
using EcoWatt.Repository.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EcoWatt.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly dbContext dbContext;
        public UsuarioRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            var result = await dbContext.Usuarios.AddAsync(usuario);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Usuario> GetUsuario(int usuarioId)
        {
            return await dbContext.Usuarios.FirstOrDefaultAsync(
                x => x.UsuarioId == usuarioId);
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await dbContext.Usuarios.ToListAsync();
        }
        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            var result = await dbContext.Usuarios.FirstOrDefaultAsync(
                x => x.UsuarioId == usuario.UsuarioId);
            if (result != null)
            {
                result.Nome = usuario.Nome;
                result.Email = usuario.Email;
                result.Senha = usuario.Senha;
                result.CEP = usuario.CEP;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task<Usuario> Login(LoginDto usuario)
        {
            var find = await dbContext.Usuarios.FirstOrDefaultAsync(
                x => x.Email == usuario.Email);
            if (find == null) 
                return null;
            if (find.Senha == usuario.Senha)
                return find;
            return null;
                  
        }
        public async Task<Usuario> Register(Usuario usuario)
        {
            var usuarioNovo = await dbContext.Usuarios.AddAsync(
                usuario);
           await dbContext.SaveChangesAsync();

            return usuarioNovo.Entity;
                
        }
        public async void DeleteUsuario(int usuarioId)
        {
            var result = await dbContext.Usuarios.FirstOrDefaultAsync(
                x => x.UsuarioId == usuarioId);
            if (result != null)
            {
                dbContext.Usuarios.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
