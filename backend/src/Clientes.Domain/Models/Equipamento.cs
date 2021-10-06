using System;

namespace Clientes.Domain.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public TipoAparelho TipoAparelhoId { get; set; }
        public TipoAparelho TipoAparelho { get; set; }
        public MarcaAparelho MarcaAparelhoId { get; set; }
        public MarcaAparelho MarcaAparelho { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Observacao { get; set; }
    }
}