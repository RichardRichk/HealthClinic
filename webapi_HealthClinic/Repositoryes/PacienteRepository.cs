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
            Paciente pacienteBuscado = _healthContext.Paciente.FirstOrDefault(x => x.Id == id)!;

            pacienteBuscado.RG = paciente.RG;
            pacienteBuscado.Usuario!.Nome = paciente.Usuario!.Nome;
            pacienteBuscado.CPF = paciente.CPF;
            pacienteBuscado.DataNascimento = paciente.DataNascimento;
            pacienteBuscado.Telefone = paciente.Telefone;
            pacienteBuscado.Endereco = paciente.Endereco;


            _healthContext.Update(pacienteBuscado);
            _healthContext.SaveChanges();
        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                Paciente search = _healthContext.Paciente
               .Select(x => new Paciente
               {
                   Id = x.Id,
                   RG = x.RG,
                   CPF = x.CPF,
                   DataNascimento = x.DataNascimento,
                   Telefone = x.Telefone,

                   Usuario = new Usuario
                   {
                       Nome = x.Usuario!.Nome

                   }

               }).FirstOrDefault(x => x.Id == id)!;

                if (search != null)
                {
                    return search;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
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
