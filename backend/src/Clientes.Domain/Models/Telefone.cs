namespace Clientes.Domain.Models
{
    public class Telefone
    {
        public int Id { get; set; }

        public int? TelefoneTipoId { get; set; }
        public TelefoneTipo TelefoneTipo { get; set; }

        public string Numero { get; set; }

        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
