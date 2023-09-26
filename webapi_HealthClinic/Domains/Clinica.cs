using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_HealthClinic.Domains
{
    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {

        [Key]
        public Guid Id { get; set; }


        [Column(TypeName = ("VARCHAR(40)"))]
        [Required(ErrorMessage = "O nome da clinica e obrigatorio!")]
        public string? Nome { get; set; }


        [Column(TypeName = ("VARCHAR(150)"))]
        [Required(ErrorMessage ="O endereco da clinica e obrigatorio!")]
        public string? Endereco { get; set; }


        [Column(TypeName = ("DATE"))]
        [Required(ErrorMessage ="o horario de abertura e obrigatorio!")]
        public DateTime HorarioAbertura { get; set; }


        [Column(TypeName =("DATE"))]
        [Required(ErrorMessage ="O horario de fechamento e obrigatorio!")]
        public DateTime HorarioFechamento { get; set; }


        [Column(TypeName = ("CHAR(60"))]
        [Required(ErrorMessage = "O CNPJ e obrigatorio!")]
        public string? CNPJ { get; set; }


        [Column(TypeName =("VARCHAR(100"))]
        [Required(ErrorMessage ="A razao social e obrigatoria!")]
        public string? RazaoSocial { get; set; }

    }
}
