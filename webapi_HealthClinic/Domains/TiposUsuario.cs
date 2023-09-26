using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_HealthClinic.Domains
{
    [Table(nameof(TiposUsuario))]
    public class TiposUsuario
    {

        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = ("VARCHAR(50)"))]
        [Required(ErrorMessage = "Tipo do usuario obrigatorio!")]
        public string? TipoUsuario { get; set; }

    }
}
