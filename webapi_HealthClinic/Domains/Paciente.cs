using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_HealthClinic.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)]
    [Index(nameof(RG), IsUnique = true)]
    public class Paciente
    {

        [Key]
        public Guid Id { get; set; }


        [Column(TypeName =("VARCHAR(100)"))]
        [Required(ErrorMessage ="O RG e obrigatorio!")]
        public string? RG { get; set; }


        [Column(TypeName =("CHAR(11)"))]
        [Required(ErrorMessage = "O CPF e obrigatorio!")]
        public string? CPF { get; set; }


        [Column(TypeName = ("DATE"))]
        [Required(ErrorMessage ="Data de nascimento e obrigatoria!")]
        public DateTime DataNascimento { get; set; }


        [Column(TypeName = ("VARCHAR(30)"))]
        [Required(ErrorMessage ="o telefone e obrigatorio!")]
        public string? Telefone { get; set; }


        [Column(TypeName =("VARCHAR(140)"))]
        [Required(ErrorMessage ="o endereco e obrigatorio!")]
        public string? Endereco { get; set; }

        //Foreign key
        [Required(ErrorMessage ="O id do usuario e obrigatorio!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }



    }
}
