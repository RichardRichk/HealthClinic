using webapi_HealthClinic.Contexts;
using webapi_HealthClinic.Domains;
using webapi_HealthClinic.Interfaces;

namespace webapi_HealthClinic.Repositoryes
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthContext;

        public UsuarioRepository()
        {
            _healthContext = new HealthContext();
        }

        public Usuario BuscarPorId(Guid id)
        {
            Usuario usuarioBuscado = _healthContext.Usuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                return (usuarioBuscado);
            }
            return null!;
        }

        public void Atualizar(Guid id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();



        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string Email, string Senha)
        {
            throw new NotImplementedException();
        }
    }
}
