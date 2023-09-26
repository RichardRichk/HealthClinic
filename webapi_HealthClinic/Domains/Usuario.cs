using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_HealthClinic.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {

        [Key]
        public Guid Id { get; set; }


        [Column(TypeName =("VARCHAR(100)"))]
        [Required(ErrorMessage = "o email e obrigatorio!")]
        public string? Email { get; set; }


        [Column(TypeName =("CHAR(80)"))]
        [Required(ErrorMessage ="a senha e obrigatoria!")]
        public string? Senha { get; set; }


        [Column(TypeName = ("VARCHAR(50)"))]
        [Required(ErrorMessage ="o nome e obrigatorio!")]
        public string? Nome { get; set; }

        //Referecia foreign key

        [Required(ErrorMessage = "o tipo usuario e obrigatorio!")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey(nameof(IdTipoUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }

    }
}
