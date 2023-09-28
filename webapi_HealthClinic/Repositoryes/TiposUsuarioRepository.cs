using webapi_HealthClinic.Contexts;
using webapi_HealthClinic.Domains;
using webapi_HealthClinic.Interfaces;

namespace webapi_HealthClinic.Repositoryes
{
    public class TiposUsuarioRepository : ITipoUsuarioRepository
    {

        private readonly HealthContext _healthContext;


        public TiposUsuarioRepository()
        {
            _healthContext = new HealthContext();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            TiposUsuario tipoUsuarioBuscado = _healthContext.TiposUsuario.Find(id);

            return (tipoUsuarioBuscado);
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            tipoUsuario.Id = Guid.NewGuid();

            _healthContext.TiposUsuario.Add(tipoUsuario);

            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tipoUsuarioBuscado = _healthContext.TiposUsuario.Find(id);

            _healthContext.TiposUsuario.Remove(tipoUsuarioBuscado);

            _healthContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _healthContext.TiposUsuario.ToList();    
        }
    }
}
