using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWatt.Models
{
    [Table("_Consumo")]
    public class Consumo
    {
        [Key]
        public int ConsumoId { get; set; }
        [Column("dt_consumo")]
        public DateTime Data_Consumo { get; set; } = DateTime.Now;
        [Column("qt_horas_uso")]
        public string Hora_Consumo { get; set; }
        [Column("vl_consumo_watts")]
        public int Quantidade_Watts { get; set; }
    }
}
