using System;

namespace Clientes.Domain.Models
{
    public class Equipamento
    {
        public int Id { get; set; }

        public int? EquipamentoTipoId { get; set; }
        public EquipamentoTipo EquipamentoTipo { get; set; }
        
        public int? EquipamentoMarcaId { get; set; }
        public EquipamentoMarca EquipamentoMarca { get; set; }
        
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Observacao { get; set; }
    }
}