using System.Collections.Generic;

namespace Clientes.Domain.Models
{
    public class MarcaAparelho
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public IEnumerable<Equipamento> Equipamentos { get; set; }
    }
}