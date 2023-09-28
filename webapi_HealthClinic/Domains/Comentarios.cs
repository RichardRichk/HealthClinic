using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_HealthClinic.Domains
{
    [Table(nameof(Comentarios))]
    public class Comentarios
    {

        [Key]
        public Guid Id { get; set; }


        [Column(TypeName = ("VARCHAR(120)"))]
        public string? Comentario { get; set; }


        [Column(TypeName = ("BIT"))]
        public bool? Exibe { get; set; }


        //Foreign key

        [Required(ErrorMessage ="o id do paciente e obrigatorio!")]
        public Guid IdPaciente { get; set; }


        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

    }
}
