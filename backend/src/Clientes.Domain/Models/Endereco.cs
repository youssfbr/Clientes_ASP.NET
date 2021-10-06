namespace Clientes.Domain.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int? BairroId { get; set; }
        public Bairro Bairro { get; set; }
        public int? CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}