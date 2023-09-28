using webapi_HealthClinic.Domains;

namespace webapi_HealthClinic.Interfaces
{
    public interface IUsuarioRepository
    {

        void Cadastrar(Usuario usuario);


        void Deletar(Guid id);


        void Atualizar(Guid id, Usuario usuario);


        Usuario BuscarPorId(Guid id);


        Usuario Login(string Email, string Senha);

    }
}
