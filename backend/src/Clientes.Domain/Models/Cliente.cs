using System;
using System.Collections.Generic;

namespace Clientes.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }        
        public string CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Observacao { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }        
        public Endereco Endereco { get; set; }        
    }
}