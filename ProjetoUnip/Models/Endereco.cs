using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUnip.Models
{
    [Table("Tb_Endereco")]
    public class Endereco
    {
        internal virtual ICollection<Pessoa> Pessoas { get; set; }

        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Logradouro")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Column("Cep")]
        [Display(Name ="Cep")]
        public string Cep { get; set; }

        [Column("Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Column("Numero")]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Column("Estado")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }


    }
}
