using System;
using System.Collections.Generic;
using System.Linq;
using Clientes.Domain.Models;
using Clientes.Persistence.Data;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]" + "s")]
    public class ClienteController : ControllerBase
    {        
        private readonly DataContext _context;
        public ClienteController(DataContext context) { 
            _context = context;
        }                     

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _context.Clientes;             
        }

        [HttpGet("{id}")]
        public Cliente GetById(int id)
        {
            return _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        }
    }
}
