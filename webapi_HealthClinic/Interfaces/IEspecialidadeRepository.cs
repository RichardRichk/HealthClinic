using webapi_HealthClinic.Domains;

namespace webapi_HealthClinic.Interfaces
{
    public interface IEspecialidadeRepository
    {

        void Cadastrar(Especialidades especialidade);

        void Deletar(Guid id);


        void Atualizar(Guid id, Especialidades especialidade);


        List<Especialidades> Listar();


        Especialidades BuscarPorId(Guid id);

    }
}
