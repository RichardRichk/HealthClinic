using webapi_HealthClinic.Contexts;
using webapi_HealthClinic.Domains;
using webapi_HealthClinic.Interfaces;

namespace webapi_HealthClinic.Repositoryes
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext _healthContext;


        public PacienteRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Paciente paciente)
        {
            Paciente pacienteAtualizado = _healthContext.Paciente.FirstOrDefault(x => x.Id == id);

            if (pacienteAtualizado != null)
            {

                pacienteAtualizado.RG = paciente.RG;

                pacienteAtualizado.Telefone = paciente.Telefone;

                pacienteAtualizado.CPF = paciente.CPF;

                pacienteAtualizado.Endereco = paciente.Endereco;

                _healthContext.Update(pacienteAtualizado);

                _healthContext.SaveChanges();
            }
        }

        public Paciente BuscarPorId(Guid id)
        {
            Paciente pacienteBuscasdo = _healthContext.Paciente.FirstOrDefault(c => c.Id == id);

            if (pacienteBuscasdo != null)
            {
                return (pacienteBuscasdo);

            }
            return null!;

        }

        public void Cadastrar(Paciente paciente)
        {
            paciente.Id = Guid.NewGuid();
            _healthContext.Add(paciente);

            _healthContext.SaveChanges();

        }

        public void Deletar(Guid id)
        {

            try
            {
                Paciente pacienteDelete = _healthContext.Paciente.Find(id);

                if (pacienteDelete != null)
                {
                    _healthContext.Remove(pacienteDelete);

                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Paciente> Listar()
        {
            return _healthContext.Paciente.ToList();
        }
    }
}
