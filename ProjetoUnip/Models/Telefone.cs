using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUnip.Models
{
    [Table("Tb_Telefone")]
    public class Telefone
    {
        internal virtual ICollection<Pessoa> Pessoas { get; set; }

        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("NumeroDeTelefone")]
        [Display(Name = "NumeroDeTelefone")]
        public int NumeroDeTelefone { get; set; }

        [Column("DDD")]
        [Display(Name = "DDD")]
        public int DDD { get; set; }

        [Column("Tipo")]
        [Display(Name = "Tipo")]
        public TipoTelefone TipoTelefone { get; set; }
        public int Id_FKTipoTelefone { get; set; }

        


    }
}
