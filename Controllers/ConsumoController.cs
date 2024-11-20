using EcoWatt.Models;
using EcoWatt.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EcoWatt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoController : ControllerBase
    {
        private readonly IConsumoRepository _consumoRepository;
        public ConsumoController(IConsumoRepository consumo)
        {
            _consumoRepository = consumo;
        }
        /// <summary>
        /// Endpoint que obtem a lista de todos os consumos
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de consumos</response>
        /// <response code="500"> Erro ao obter consumo</response>
        /// <response code="404"> Lista de consumo nao encontrado</response>
        [HttpGet]
        public async Task<ActionResult<Consumo>> GetConsumo()
        {
            try
            {
                return Ok(await _consumoRepository.GetConsumos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter o consumo total!");
            }
        }
        /// <summary>
        /// Endpoint que obtem consumos por id
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna o consumo pelo id</response>
        /// <response code="500"> Erro ao obter id do consumo</response>
        /// <response code="404"> Consumo com o id nao encontrado</response>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Consumo>> GetConsumo(int id)
        {
            try
            {
                var result = await _consumoRepository.GetConsumo(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter o consumo total!");
            }
        }
        /// <summary>
        /// Endpoint para cadastrar novos valores de consumos
        /// </summary>
        /// <returns>Retorna o  Estabelecimento</returns>
        ///
        /// <response code="201"> Salva o consumo</response>
        /// <response code="500"> Erro ao salvar o consumo</response>
        /// <response code="400"> Verifique os valores</response>
        /// 
        [HttpPost]
        public async Task<ActionResult<Consumo>> AddConsumo([FromBody] Consumo consumo)
        {
            try
            {
                if (consumo == null) return BadRequest();

                var createConsumo = await _consumoRepository.AddConsumo(consumo);

                return CreatedAtAction(nameof(GetConsumo),
                    new { id = createConsumo.ConsumoId }, createConsumo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar metodo de calculo de consumo!");
            }
        }
        /// <summary>
        /// Endpoint que atualiza valores de consumo
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Valores do consumo atualizado</response>
        /// <response code="500"> Erro ao atualizar dados do consumo</response>
        /// <response code="404"> Consumo nao encontrado </response>
        /// 
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Consumo>> UpdateConsumo([FromBody] Consumo consumo)
        {
            try
            {
                var consumoUpdate = await _consumoRepository.GetConsumo(consumo.ConsumoId);

                if (consumoUpdate == null)
                    return NotFound($"Calculo do consumo com id {consumo.ConsumoId} não encontrado");

                var updatedConsumo = await _consumoRepository.UpdateConsumo(consumo);

                return Ok(updatedConsumo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar o cálculo!");
            }
        }

        /// <summary>
        /// Endpoint que deleta valores de consumo
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Consumo deletado</response>
        /// <response code="500"> Erro ao deletar consumo</response>
        /// <response code="404"> Id do consumo nao encontrado </response>
        /// 
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteConsumo(int id)
        {
            try
            {
                var consumoDelete = await _consumoRepository.GetConsumo(id);

                if (consumoDelete == null)
                    return NotFound($"Consumo com id {id} não encontrado");

                _consumoRepository.DeleteConsumo(id);

                return Ok($"Consumo com id {id} deletado");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar o consumo: {ex.Message}");
            }
        }

    }
}
