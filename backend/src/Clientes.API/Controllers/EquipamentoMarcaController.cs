using System;
using System.Threading.Tasks;
using Clientes.Application.Interfaces;
using Clientes.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]" + "s")]
    public class EquipamentoMarcaController : ControllerBase
    {
        private readonly IEquipamentoMarcaService _equipamentoMarcaService;

        public EquipamentoMarcaController(IEquipamentoMarcaService equipamentoMarcaService)
        {
            _equipamentoMarcaService = equipamentoMarcaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            try
            {
                 var equipamentosMarcas = await _equipamentoMarcaService.GetAllEquipamentosMarcasAsync();
                if (equipamentosMarcas == null) return NotFound("Nenhum bairro encontrado.");

                return Ok(equipamentosMarcas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar bairros. Erro: {ex.Message}");                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var equipamentoMarca = await _equipamentoMarcaService.GetEquipamentoMarcaByIdAsync(id);
                 if (equipamentoMarca == null) return NotFound("Nenhum marca de equipamento encontrada.");

                 return Ok(equipamentoMarca);
            }
            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar a marca do equipamento. Erro: {ex.Message}");
            }
        }

        [HttpGet("{marca}/marca")]
        public async Task<IActionResult> GetByMarca(string marca)
        {
            try
            {
                 var equipamentosMarcas = await _equipamentoMarcaService.GetAllEquipamentosMarcasByMarcaAsync(marca);
                 if (equipamentosMarcas == null) return NotFound("Nenhum marca de equipamento encontrada.");

                 return Ok(equipamentosMarcas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar a marca do equipamento. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipamentoMarca(EquipamentoMarca model)
        {
            try
            {
                var equipamentoMarca = await _equipamentoMarcaService.AddEquipamentoMarca(model);
                if (equipamentoMarca == null) return BadRequest("Erro ao tentar adicionar o equipamentoMarca.");

                return Created("", equipamentoMarca);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro Interno. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipamentoMarca(int id, EquipamentoMarca model)
        {
            try
            {
                var equipamentoMarca = await _equipamentoMarcaService.UpdateEquipamentoMarca(id, model);
                if (equipamentoMarca == null) return NotFound("Erro ao tentar atualizar a marca do equipamento.");

                return Ok(equipamentoMarca);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro interno. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {                  
                 return await _equipamentoMarcaService.DeleteEquipamentoMarca(id) ?
                    NoContent() :
                    NotFound("Marca do equipamento não encontrada.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar. Erro: {ex.Message}");
            }
        }

    }
}