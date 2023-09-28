using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_HealthClinic.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {

        [Key]
        public Guid Id { get; set; }


        [Column(TypeName =("VARCHAR(20)"))]
        [Required(ErrorMessage ="O CRM e obrigatorio!")]
        public string? CRM { get; set; }


        //foreign key

        [Required(ErrorMessage ="O id usuario e obrigatorio")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }



        [Required(ErrorMessage = "O id clinica e obrigatorio")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }



        [Required(ErrorMessage = "O id especialista e obrigatorio")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidades? Especialidade { get; set; }


    }
}
