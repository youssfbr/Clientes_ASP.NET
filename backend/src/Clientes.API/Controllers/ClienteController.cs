using System;
using System.Collections.Generic;
using Clientes.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]" + "s")]
    public class ClienteController : ControllerBase
    {
        public ClienteController() { }       

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return new Cliente[] 
            {
                new Cliente() 
                {
                    Id = 1,
                    Nome = "Alisson Youssf",
                    Email = "youssfbr@gmail.com",
                    Telefone = "+55 (85) 9.8705.9184",
                    DataCadastro = DateTime.Now,
                    CPF = "12345567"
                },
                new Cliente() 
                {
                    Id = 2,
                    Nome = "Link da Silva Sauro",
                    Email = "linlin@gmail.com",
                    Telefone = "+55 (85) 9.8128-6510",
                    DataCadastro = DateTime.Now,
                    CPF = "12345563"
                }
            };            
        }
    }
}
