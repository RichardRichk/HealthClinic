using webapi_HealthClinic.Domains;

namespace webapi_HealthClinic.Interfaces
{
    public interface IComentariosRepository
    {

        void Cadastrar(Comentarios comentario);


        void Deletar(Guid id);


        void Atualizar(Guid id, Comentarios comentario);


        List<Comentarios> Listar();


        Comentarios BuscarPorId(Guid id);
    }
}
