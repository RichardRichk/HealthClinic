using webapi_HealthClinic.Domains;

namespace webapi_HealthClinic.Interfaces
{
    public interface ITipoUsuarioRepository
    {

        void Cadastrar(TiposUsuario tipoUsuario);

        void Deletar(Guid id);

        List<TiposUsuario> Listar();


        TiposUsuario BuscarPorId(Guid id);

    }
}
