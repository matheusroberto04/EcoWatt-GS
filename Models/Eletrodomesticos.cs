using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWatt.Models
{
    [Table("_Eletrodomesticos")]
    public class Eletrodomesticos
    {
        [Key]
        public int EletrodomesticosId { get; set; }
        [Column("nm_nome")]
        public string Nome_Aparelho { get; set; }
        [Column("vl_aparelho_consumo_watts")]
        public int Valor_Consumo_Watts { get; set; }
        [Column("ds_categoria")]
        public string Categoria { get; set; } = string.Empty;
        [Column("ds_modelo")]
        public string Modelo {  get; set; } = string.Empty;
    }
}
