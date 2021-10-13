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
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamentoService _equipamentoService;

        public EquipamentoController(IEquipamentoService equipamentoService)
        {
            _equipamentoService = equipamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            try
            {
                 var equipamentos = await _equipamentoService.GetAllEquipamentosAsync();
                if (equipamentos == null) return NotFound("Nenhum equipamento encontrado.");

                return Ok(equipamentos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar equipamentos. Erro: {ex.Message}");                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var equipamento = await _equipamentoService.GetEquipamentoByIdAsync(id);
                 if (equipamento == null) return NotFound("Nenhum equipamento encontrado.");

                 return Ok(equipamento);
            }
            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar o equipamento. Erro: {ex.Message}");
            }
        }

        [HttpGet("{modelo}/modelo")]
        public async Task<IActionResult> GetByModeloDoEquipamento(string modelo)
        {
            try
            {
                 var equipamento = await _equipamentoService.GetAllEquipamentosByModeloAsync(modelo);
                 if (equipamento == null) return NotFound("Nenhum equipamento encontrado.");

                 return Ok(equipamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar equipamentos. Erro: {ex.Message}");
            }
        }

       /* [HttpGet("{modelo}/modelo")]
        public async Task<IActionResult> GetByNumeroSerieDoEquipamento(string modelo)
        {
            try
            {
                 var equipamento = await _equipamentoService.GetEquipamentoByNumeroSerieAsync(modelo);
                 if (equipamento == null) return NotFound("Nenhum equipamento encontrado.");

                 return Ok(equipamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar equipamentos. Erro: {ex.Message}");
            }
        }*/

        [HttpPost]
        public async Task<IActionResult> AddEquipamento(Equipamento model)
        {
            try
            {
                var equipamento = await _equipamentoService.AddEquipamento(model);
                if (equipamento == null) return BadRequest("Erro ao tentar adicionar o Equipamento.");

                return Created("", equipamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro Interno. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipamento(int id, Equipamento model)
        {
            try
            {
                var equipamento = await _equipamentoService.UpdateEquipamento(id, model);
                if (equipamento == null) return NotFound("Erro ao tentar atualizar o Equipamento. Equipamento inexistente.");

                return Ok(equipamento);
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
                 return await _equipamentoService.DeleteEquipamento(id) ?
                    NoContent() :
                    NotFound("Equipamento não encontrado.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar. Erro: {ex.Message}");
            }
        }

    }
}