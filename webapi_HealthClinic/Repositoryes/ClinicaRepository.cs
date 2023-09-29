using webapi_HealthClinic.Contexts;
using webapi_HealthClinic.Domains;
using webapi_HealthClinic.Interfaces;

namespace webapi_HealthClinic.Repositoryes
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext _healthContext;
        

        public ClinicaRepository()
        {
            _healthContext = new HealthContext();   
        }


        public void Atualizar(Guid id, Clinica clinica)
        {
            throw new NotImplementedException();
        }

        public Clinica BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Clinica clinica)
        {
            clinica.Id = Guid.NewGuid();

            
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Clinica> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
