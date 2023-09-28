using webapi_HealthClinic.Domains;

namespace webapi_HealthClinic.Interfaces
{
    public interface IConsultaRepository
    {

        void Cadastrar(Consulta consulta);


        void Deletar(Guid id);


        void Atualizar(Guid id, Consulta consulta);


        List<Consulta> Listar();


        Consulta BuscarPorId(Guid id);

    }
}
