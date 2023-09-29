using webapi_HealthClinic.Contexts;
using webapi_HealthClinic.Domains;
using webapi_HealthClinic.Interfaces;

namespace webapi_HealthClinic.Repositoryes
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {

        private readonly HealthContext _healthContext;


        public EspecialidadeRepository()
        {
            _healthContext = new HealthContext();
        }

        public Especialidades BuscarPorId(Guid id)
        {
            Especialidades tipoUsuarioBuscado = _healthContext.Especialidades.Find(id);

            return (tipoUsuarioBuscado);
        }

        public void Cadastrar(Especialidades tipoUsuario)
        {
            tipoUsuario.Id = Guid.NewGuid();

            _healthContext.Especialidades.Add(tipoUsuario);

            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Especialidades tipoUsuarioBuscado = _healthContext.Especialidades.Find(id);

            _healthContext.Especialidades.Remove(tipoUsuarioBuscado);

            _healthContext.SaveChanges();
        }

        public List<Especialidades> Listar()
        {
            return _healthContext.Especialidades.ToList();
        }

    }
}
