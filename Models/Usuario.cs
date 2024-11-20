using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWatt.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId {  get; set; }
        [Column("nm_nome")]
        public string Nome { get; set; } = string.Empty;
        [Column("ds_email")]
        public string Email { get; set; } = string.Empty;
        [Column("cd_senha")]
        public int Senha { get; set; }
        [Column("cd_cep")]
        public string CEP {  get; set; } 
    }
}
