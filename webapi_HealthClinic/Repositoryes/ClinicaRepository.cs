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
            Clinica clinicaBuscada = _healthContext.Clinica.FirstOrDefault(c => c.Id == id);

            if (clinicaBuscada != null)
            {
                clinicaBuscada.Nome = clinica.Nome;

                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;

                clinicaBuscada.CNPJ = clinica.CNPJ;

                clinicaBuscada.HorarioAbertura = clinica.HorarioAbertura;

                clinicaBuscada.HorarioFechamento = clinica.HorarioFechamento;

                clinicaBuscada.Endereco = clinica.Endereco;

                _healthContext.Update(clinicaBuscada);

                _healthContext.SaveChanges();
            }


        }

        public Clinica BuscarPorId(Guid id)
        {
            Clinica clinicaBuscasda = _healthContext.Clinica.FirstOrDefault(c => c.Id == id);

            if (clinicaBuscasda != null)
            {
                return (clinicaBuscasda);

            }
            return null!;

        }

        public void Cadastrar(Clinica clinica)
        {
            clinica.Id = Guid.NewGuid();

            _healthContext.Add(clinica);

            _healthContext.SaveChanges();
            
        }

        public void Deletar(Guid id)
        {

            try
            {
                Clinica clinicaDelete = _healthContext.Clinica.Find(id);

                if (clinicaDelete != null)
                {
                    _healthContext.Remove(clinicaDelete);

                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<Clinica> Listar()
        {
            return _healthContext.Clinica.ToList();
        }
    }
}
