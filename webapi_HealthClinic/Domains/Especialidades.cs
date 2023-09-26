using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_HealthClinic.Domains
{
    [Table(nameof(Especialidades))]
    public class Especialidades
    {

        [Key]
        public Guid Id { get; set; }


        [Column(TypeName = ("VARCHAR(40)"))]
        [Required(ErrorMessage ="o nome da especialidade e obrigatoria!")]
        public string? Especialidade { get; set; }


    }
}
