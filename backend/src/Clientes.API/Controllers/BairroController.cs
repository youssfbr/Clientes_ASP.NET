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
    public class BairroController : ControllerBase
    {
        private readonly IBairroService _bairroService;

        public BairroController(IBairroService bairroService)
        {
            _bairroService = bairroService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {   
            try
            {
                 var bairros = await _bairroService.GetAllBairrosAsync();
                if (bairros == null) return NotFound("Nenhum bairro encontrado.");

                return Ok(bairros);
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
                 var bairro = await _bairroService.GetBairroByIdAsync(id);
                 if (bairro == null) return NotFound("Nenhum bairro encontrado.");

                 return Ok(bairro);
            }
            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar o bairro. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                 var bairro = await _bairroService.GetAllBairrosByNomeAsync(nome);
                 if (bairro == null) return NotFound("Nenhum bairro encontrado.");

                 return Ok(bairro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar bairros. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBairro(Bairro model)
        {
            try
            {
                var bairro = await _bairroService.AddBairro(model);
                if (bairro == null) return BadRequest("Erro ao tentar adicionar o bairro.");

                return Created("", bairro);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro Interno. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBairro(int id, Bairro model)
        {
            try
            {
                var bairro = await _bairroService.UpdateBairro(id, model);
                if (bairro == null) return BadRequest("Erro ao tentar atualizar o bairro. Bairro inexistente.");

                return Ok(bairro);
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
                 return await _bairroService.DeleteBairro(id) ?
                    Ok("Deletado") :
                    NotFound("Bairro não encontrado.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar. Erro: {ex.Message}");
            }
        }

    }
}