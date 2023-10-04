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

        public void Atualizar(Guid id, Usuario usuario)
        {
            throw new NotImplementedException();
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

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha);

                _healthContext.Usuario.Add(usuario);
                


                _healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Usuario usuarioBuscado = _healthContext.Usuario.Find(id);

            _healthContext.Usuario.Remove(usuarioBuscado);

            _healthContext.SaveChanges();

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

