using System.ComponentModel.DataAnnotations;

namespace webapi.event_.manha.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "email e obrigatorio!")]
        public string Email { get; set; }


        [Required(ErrorMessage ="senha e obrigatoria!")]
        public string Senha { get; set; }

    }
}
