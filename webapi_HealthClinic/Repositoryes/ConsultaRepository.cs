using webapi_HealthClinic.Contexts;
using webapi_HealthClinic.Domains;
using webapi_HealthClinic.Interfaces;

namespace webapi_HealthClinic.Repositoryes
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext _healthContext;


        public ConsultaRepository()
        {
            _healthContext = new HealthContext();
        }



        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta consultaBuscada = _healthContext.Consulta.FirstOrDefault(c => c.Id == id);

            if (consultaBuscada != null)
            {
                consultaBuscada.Data = consulta.Data;

                consultaBuscada.Hora = consulta.Hora;

                consultaBuscada.Prontuario = consulta.Prontuario;

                _healthContext.Update(consultaBuscada);

                _healthContext.SaveChanges();
            }
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                Consulta search = _healthContext.Consulta
               .Select(x => new Consulta
               {
                   Id = x.Id,
                   Data = x.Data,
                   Hora = x.Hora,
                   Prontuario = x.Prontuario,


                   Medico = new Medico
                   {
                       Especialidade = x.Medico.Especialidade,
                       
                       Usuario = new Usuario
                       {
                           Nome = x.Medico.Usuario.Nome,
                       }
                   },

                   Paciente = new Paciente
                   {
                       Usuario = new Usuario
                       {
                           Nome = x.Paciente.Usuario.Nome,
                       }
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

        public void Cadastrar(Consulta consulta)
        {
            consulta.Id = Guid.NewGuid();

            _healthContext.Consulta.Add(consulta);

            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Consulta consultaDelete = _healthContext.Consulta.Find(id);

                if (consultaDelete != null)
                {
                    _healthContext.Remove(consultaDelete);

                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consulta> Listar()
        {
            return _healthContext.Consulta.ToList();
        }
    }
}
