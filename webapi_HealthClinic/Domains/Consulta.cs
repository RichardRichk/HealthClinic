using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_HealthClinic.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {

        [Key]
        public Guid Id { get; set; }


        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="A data e obrigatoria!")]
        public DateTime Data { get; set; }


        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "A hora e obrigatoria!")]
        public TimeSpan Hora { get; set; }


        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="o prontuario e obrigatorio")]
        public string? Prontuario { get; set; }



        //foreign key

        [Required(ErrorMessage ="o id do medico e obrigatorio!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }




        [Required(ErrorMessage = "o id do paciente e obrigatorio!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }



        [Required(ErrorMessage = "o id do comentario e obrigatorio!")]
        public Guid IdComentario { get; set; }

        [ForeignKey(nameof(IdComentario))]
        public Comentarios? Comentarios { get; set; }
    }
}
