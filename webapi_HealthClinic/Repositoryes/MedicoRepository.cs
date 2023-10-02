using webapi_HealthClinic.Contexts;
using webapi_HealthClinic.Domains;
using webapi_HealthClinic.Interfaces;

namespace webapi_HealthClinic.Repositoryes
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext _healthContext;


        public MedicoRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Medico medico)
        {
            Medico medicoBuscado = _healthContext.Medico.FirstOrDefault(m => m.Id == id);

            if (medicoBuscado != null)
            {
                medicoBuscado.CRM = medico.CRM;

                medicoBuscado.Clinica = medico.Clinica;

                medicoBuscado.Especialidade = medico.Especialidade;
            }
        }

        public Medico BuscarPorId(Guid id)
        {
            Medico medicoBuscasdo = _healthContext.Medico.FirstOrDefault(c => c.Id == id)!;

            if (medicoBuscasdo != null)
            {
                return (medicoBuscasdo);

            }
            return null!;

        }

        public void Cadastrar(Medico medico)
        {
            medico.Id = Guid.NewGuid();
            _healthContext.Add(medico);

            _healthContext.SaveChanges();

        }

        public void Deletar(Guid id)
        {

            try
            {
                Medico MedicoDelete = _healthContext.Medico.Find(id)!;

                if (MedicoDelete != null)
                {
                    _healthContext.Remove(MedicoDelete);

                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Medico> Listar()
        {
            return _healthContext.Medico.ToList();
        }
    }
