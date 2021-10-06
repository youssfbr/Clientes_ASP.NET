using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Application.Interfaces;
using Clientes.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]" + "s")]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _cidadeService;
        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            try
            {
                var cidades = await _cidadeService.GetAllCidadesAsync();
                if (cidades == null) return NotFound("Nenhuma cidade encontrada.");

                return Ok(cidades);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cidades. Erro: {ex.Message}");                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var cidade = await _cidadeService.GetCidadeByIdAsync(id);
                 if (cidade == null) return NotFound("Nenhuma cidade encontrada.");

                 return Ok(cidade);
            }
            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cidades. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                 var cidades = await _cidadeService.GetAllCidadesByNomeAsync(nome);
                 if (cidades == null) return NotFound("Nenhuma cidade encontrada.");

                 return Ok(cidades);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar bairros. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCidade(Cidade model)
        {
            try
            {
                var cidade = await _cidadeService.AddCidade(model);
                if (cidade == null) return BadRequest("Erro ao tentar adicionar a cidade.");

                return Created("", cidade);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro Interno. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCidade(int id, Cidade model)
        {
            try
            {
                var cidade = await _cidadeService.UpdateCidade(id, model);
                if (cidade == null) return NotFound("Erro ao tentar atualizar a cidade. Cidade inexistente.");

                return Ok(cidade);
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
                 return await _cidadeService.DeleteCidade(id) ?
                    NoContent() :
                    NotFound("Cidade não encontrada.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar. Erro: {ex.Message}");
            }
        }
    }
}