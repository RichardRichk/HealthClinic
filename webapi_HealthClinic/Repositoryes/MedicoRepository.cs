using Microsoft.EntityFrameworkCore;
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

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                Medico search = _healthContext.Medico
               .Select(x => new Medico
               {
                   Id = x.Id,
                   CRM = x.CRM,

                   Usuario = new Usuario
                   {
                       Nome = x.Usuario!.Nome

                   },

                   Clinica = new Clinica
                   {
                       Nome = x.Clinica!.Nome,
                       Endereco = x.Clinica!.Endereco
                   },

                   Especialidade = new Especialidades
                   {
                       Especialidade = x.Especialidade!.Especialidade,
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

        public void Atualizar(Guid id, Medico medico)
        {
            Medico bus = _healthContext.Medico.FirstOrDefault(x => x.Id == id)!;

            bus.CRM = medico.CRM;
            bus.Usuario!.Nome = medico.Usuario!.Nome;
            bus.Clinica!.Nome = medico.Clinica!.Nome;
            bus.Clinica!.Endereco = medico.Clinica!.Endereco;
            bus.Especialidade!.Especialidade = medico.Especialidade!.Especialidade;


            _healthContext.Update(bus);
            _healthContext.SaveChanges();
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
}
