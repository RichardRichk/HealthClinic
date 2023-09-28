using webapi_HealthClinic.Domains;

namespace webapi_HealthClinic.Interfaces
{
    public interface IMedicoRepository
    {

        void Cadastrar(Medico medico);


        void Deletar(Guid id);


        void Atualizar(Guid id, Medico medico);


        List<Medico> Listar();


        Medico BuscarPorId(Guid id);

    }
}
