using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUnip.Models
{
    [Table("tb_Pessoa")]
    public class Pessoa
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get ; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Column("Endereco")]
        [Display(Name = "Endereco")]
        public virtual Endereco Endereco { get; set; }

        public int Id_Endereco { get; set; }

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public virtual Telefone Telefone { get; set; }

        public int Id_Telefone { get; set; }


    }
}
