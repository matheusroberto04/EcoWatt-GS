using EcoWatt.Models;
using EcoWatt.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EcoWatt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EletrodomesticosController : ControllerBase
    {
        private readonly IEletrodomesticosRepository _eletrodomesticosRepository;
        public EletrodomesticosController(IEletrodomesticosRepository eletrodomesticos)
        {
            _eletrodomesticosRepository = eletrodomesticos;
        }
        /// <summary>
        /// Endpoint que obtem a lista de todos os eletrodomesticos
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de todos os eletrodomesticos</response>
        /// <response code="500"> Erro ao obter eletrodomesticos</response>
        /// <response code="404"> Lista de eletrodomesticos nao encontrada</response>
        [HttpGet]
        public async Task<ActionResult<Eletrodomesticos>> GetEletrodomesticos()
        {
            try
            {
                return Ok(await _eletrodomesticosRepository.GetEletrodomesticos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter o eletrodomestico desejado!");
            }
        }
        /// <summary>
        /// Endpoint que obtem eletrodomesticos por id
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna o eletrodomestico pelo id informado</response>
        /// <response code="500"> Erro ao obter o eletrodomestico</response>
        /// <response code="404"> Eletrodomestico nao encontrado</response>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Eletrodomesticos>> GetEletrodomesticos(int id)
        {
            try
            {
                var result = await _eletrodomesticosRepository.GetEletrodomesticos(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter o eletrodomestico desejado!");
            }
        }
        /// <summary>
        /// Endpoint que registra um novo eletrodomestico
        /// </summary>
        /// <returns></returns>
        /// <response code="201"> Cadastra um novo eletrodomestico</response>
        /// <response code="500"> Erro ao cadastrar eletrodomestico</response>
        /// <response code="400"> Eletrodomestico nao cadastrado</response>
        [HttpPost]
        public async Task<ActionResult<Eletrodomesticos>> AddEletrodomesticos([FromBody] Eletrodomesticos eletrodomesticos)
        {
            try
            {
                if (eletrodomesticos == null) return BadRequest();

                var createEletrodomesticos = await _eletrodomesticosRepository.AddEletrodomesticos(eletrodomesticos);

                return CreatedAtAction(nameof(GetEletrodomesticos),
                    new { id = createEletrodomesticos.EletrodomesticosId }, createEletrodomesticos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro para adicionar o eletrodomestico!");
            }
        }
        /// <summary>
        /// Endpoint que atualiza dados dos eletrodomesticos
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Dados do eletrodomestico atualizados com sucesso</response>
        /// <response code="500"> Erro ao atualizar dados</response>
        /// <response code="404"> Dados nao atualizados </response>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Eletrodomesticos>> UpdateEletrodomesticos([FromBody] Eletrodomesticos eletrodomesticos)
        {
            try
            {
                var eletrodomesticosUpdate = await _eletrodomesticosRepository.GetEletrodomesticos(eletrodomesticos.EletrodomesticosId);

                if (eletrodomesticosUpdate == null) return NotFound($"Eletrodomestico com id {eletrodomesticos.EletrodomesticosId} não encontrada");

                return await _eletrodomesticosRepository.UpdateEletrodomesticos(eletrodomesticos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados do eletrodomestico");
            }
        }
        /// <summary>
        /// Endpoint que deleta eletrodomesticos
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Eletrodomestico deletado com sucesso</response>
        /// <response code="500"> Erro ao deletar eletrodomestico</response>
        /// <response code="404"> Eletrodomestico nao deletado</response>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEletrodomesticos(int id)
        {
            try
            {
                var eletrodomesticosDelete = await _eletrodomesticosRepository.GetEletrodomesticos(id);

                if (eletrodomesticosDelete == null) return NotFound($"Eletrodomestico com id {id} não encontrado");

                _eletrodomesticosRepository.DeleteEletrodomesticos(id);

                return Ok($"Eletrodomestico com id {id} deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar eletrodomestico");
            }
        }

    }
}
