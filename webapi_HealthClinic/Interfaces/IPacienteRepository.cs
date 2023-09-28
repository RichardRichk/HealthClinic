using webapi_HealthClinic.Domains;

namespace webapi_HealthClinic.Interfaces
{
    public interface IPacienteRepository
    {

        void Cadastrar(Paciente paciente);


        void Deletar(Guid id);


        void Atualizar(Guid id, Paciente paciente);


        List<Paciente> Listar();


        Paciente BuscarPorId(Guid id);

    }
}
