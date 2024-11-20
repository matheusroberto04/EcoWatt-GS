using Google.Type;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWatt.Models
{
    public class Consumo
    {
        [Key]
        public int ConsumoId { get; set; }
        [Column("dt_consumo")]
        public string Data_Consumo {  get; set; }
        [Column("qt_horas_uso")]
        public string Hora_Consumo { get; set; }
        [Column("vl_consumo_watts")]
        public int Quantidade_Watts { get; set; }
    }
}
