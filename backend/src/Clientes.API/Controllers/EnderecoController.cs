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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            try
            {
                 var enderecos = await _enderecoService.GetAllEnderecosAsync();
                if (enderecos == null) return NotFound("Nenhum endereço encontrado.");

                return Ok(enderecos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar endereco. Erro: {ex.Message}");                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var endereco = await _enderecoService.GetEnderecoByIdAsync(id);
                 if (endereco == null) return NotFound("Nenhum endereco encontrado.");

                 return Ok(endereco);
            }
            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar o endereco. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                 var endereco = await _enderecoService.GetAllEnderecosByNomeAsync(nome);
                 if (endereco == null) return NotFound("Nenhum endereco encontrado.");

                 return Ok(endereco);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar enderecos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEndereco(Endereco model)
        {
            try
            {
                var endereco = await _enderecoService.AddEndereco(model);
                if (endereco == null) return BadRequest("Erro ao tentar adicionar o endereco.");

                return Created("", endereco);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro Interno. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEndereco(int id, Endereco model)
        {
            try
            {
                var endereco = await _enderecoService.UpdateEndereco(id, model);
                if (endereco == null) return NotFound("Erro ao tentar atualizar o endereco. Endereco inexistente.");

                return Ok(endereco);
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
                 return await _enderecoService.DeleteEndereco(id) ?
                    NoContent() :
                    NotFound("endereco não encontrado.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar. Erro: {ex.Message}");
            }
        }

    }
}