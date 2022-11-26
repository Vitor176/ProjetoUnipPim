using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoUnip.Models
{
    [Table("Tb_TipoTelefone")]
    public class TipoTelefone
    {
        internal virtual ICollection<Telefone> Telefones { get; set; }

        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Tipo")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
    }
}