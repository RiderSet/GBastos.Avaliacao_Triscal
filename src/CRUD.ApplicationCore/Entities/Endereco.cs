using System.ComponentModel.DataAnnotations;

namespace CRUD.ApplicationCore.Entities
{
    public class Endereco
    {
        [Key]
        public long Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
