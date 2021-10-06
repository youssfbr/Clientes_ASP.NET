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
    public class ClienteController : ControllerBase
    {        
        private readonly IClienteService _clienteService;         
        public ClienteController(IClienteService clienteService) { 
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {           
           try
           {
                var clientes = await _clienteService.GetAllClientesAsync();
                if (clientes == null) return NotFound("Nenhum cliente encontrado.");

                return Ok(clientes);
           }
           catch (Exception ex)
           {               
               return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar clientes. Erro: {ex.Message}");
           }      
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);
                if (cliente == null) return NotFound("Nenhum cliente encontrado.");

                return Ok(cliente);
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar o cliente. Erro: {ex.Message}");
            }    
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var cliente = await _clienteService.GetAllClientesByNomeAsync(nome);
                if (cliente == null) return NotFound("Nenhum cliente encontrado.");

                return Ok(cliente);
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar clientes. Erro: {ex.Message}");
            }    
        }
       
        [HttpPost]
        public async Task<IActionResult> AddCliente(Cliente model)
        {
            try
            {
                var cliente = await _clienteService.AddCliente(model);
                if (cliente == null) return BadRequest("Erro ao tentar adicionar o cliente.");

                return Created("", cliente);
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar adicionar clientes. Erro: {ex.Message}");
            }  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, Cliente model)
        {
            try
            {
                var cliente = await _clienteService.UpdateCliente(id, model);
                if (cliente == null) return NotFound("Erro ao tentar atualizar o cliente.");

                return Ok(cliente);
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar atualizar clientes. Erro: {ex.Message}");
            }  
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {                
                return await _clienteService.DeleteCliente(id) ?  
                    NoContent() : 
                    NotFound("Cliente não encontrado.");
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar deletar o cliente. Erro: {ex.Message}");
            }  
        }
    }
}
