using webapi.event_.manha.Utils;
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

        public Usuario Login(string email, string senha)
        {
            try
            {
                Usuario usuarioLogin = _healthContext.Usuario
                    .Select(u => new Usuario
                    {
                        Id = u.Id,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,
                        TiposUsuario = new TiposUsuario
                        {
                            TipoUsuario = u.TiposUsuario!.TipoUsuario,
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioLogin != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioLogin.Senha!);

                    if (confere)
                    {
                        return usuarioLogin;
                    }

                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

