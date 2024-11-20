using EcoWatt.Dtos;
using EcoWatt.Models;
using EcoWatt.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EcoWatt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuario)
        {
            _usuarioRepository = usuario;
        }
        /// <summary>
        /// Endpoint que obtem a lista de todos os usuarios
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de todos os usuarios</response>
        /// <response code="500"> Erro ao obter lista de todos os usuarios</response>
        /// <response code="404"> Lista de usuarios nao encontrada</response>
        [HttpGet]
        public async Task<ActionResult<Usuario>> GetUsuario()
        {
            try
            {
                return Ok(await _usuarioRepository.GetUsuarios());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os usuarios!");
            }
        }
        /// <summary>
        /// Endpoint que retorna usuario pelo id informado
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna o usuario pelo id informado</response>
        /// <response code="500"> Erro ao obter usuario pelo id</response>
        /// <response code="404"> Id de usuario nao encontrado</response>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var result = await _usuarioRepository.GetUsuario(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter o cliente solicitado!");
            }
        }
        /// <summary>
        /// Endpoint que cadastra novo usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="201"> Usuario cadastrado com sucesso</response>
        /// <response code="500"> Erro ao cadastrar usuario</response>
        /// <response code="400"> Usuario nao cadastrado</response>
        [HttpPost]
        public async Task<ActionResult<Usuario>> AddUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest();

                var createUsuario = await _usuarioRepository.AddUsuario(usuario);

                return CreatedAtAction(nameof(GetUsuario),
                    new { id = createUsuario.UsuarioId }, createUsuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro para cadastrar usuario");
            }
        }
        /// <summary>
        /// Endpoint que atualiza dados do usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Dados atualizados com sucesso</response>
        /// <response code="500"> Erro ao atualizar dados do usuario</response>
        /// <response code="404"> Dados nao atualizados</response>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Usuario>> UpdateUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioUpdate = await _usuarioRepository.GetUsuario(usuario.UsuarioId);

                if (usuarioUpdate == null) return NotFound($"Usuario com id {usuario.UsuarioId} não encontrado");

                return await _usuarioRepository.UpdateUsuario(usuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados do usuario");
            }
        }
        /// <summary>
        /// Endpoint de login de usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Sucesso no login</response>
        /// <response code="500"> Erro no login</response>
        /// <response code="404"> Login nao encontrado</response>
        [HttpPost("/login")]
        public async Task<ActionResult<Usuario>> Login(LoginDto usuario)
        {
            try
            {
                var loginUsuario = await _usuarioRepository.Login(usuario);

                if (loginUsuario == null)
                    return NotFound("Usuario nao encontrado");
                return loginUsuario;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Erro ao encontrar usuario");
            }
        }
        /// <summary>
        /// Endpoint de cadastro de usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Usuario cadastrado com sucesso</response>
        /// <response code="500"> Erro ao cadastrar usuario</response>
        /// <response code="404"> Usuario nao encontrado</response>
        [HttpPost("/register")]
        public async Task<ActionResult<Usuario>> Register(Usuario usuario)
        {
            return await _usuarioRepository.Register(usuario);
        }
        /// <summary>
        /// Endpoint que deleta usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Usuario deletado com sucesso</response>
        /// <response code="500"> Erro ao deletar usuario</response>
        /// <response code="404"> Usuario nao encontrado</response>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            try
            {
                var usuarioDelete = await _usuarioRepository.GetUsuario(id);

                if (usuarioDelete == null) return NotFound($"Usuario com id {id} não encontrado");

                _usuarioRepository.DeleteUsuario(id);

                return Ok($"Usuario com id {id} deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar usuario");
            }
        }
    }
}
