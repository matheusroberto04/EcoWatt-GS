using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWatt.Models
{
    [Table("_Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId {  get; set; }
        [Column("nm_nome")]
        public string Nome { get; set; } = string.Empty;
        [Column("ds_email")]
        public string Email { get; set; } = string.Empty;
        [Column("cd_senha")]
        public string Senha { get; set; }
        [Column("cd_cep")]
        public string CEP {  get; set; } 
    }
}
