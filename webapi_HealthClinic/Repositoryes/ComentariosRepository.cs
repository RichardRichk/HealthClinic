using webapi_HealthClinic.Contexts;
using webapi_HealthClinic.Domains;
using webapi_HealthClinic.Interfaces;

namespace webapi_HealthClinic.Repositoryes
{
    public class ComentariosRepository : IComentariosRepository
    {

        private readonly HealthContext _healthContext;


        public ComentariosRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Comentarios comentario)
        {
            Comentarios comentarioBuscado = _healthContext.Comentarios.FirstOrDefault(c => c.Id == id);

            if (comentarioBuscado != null)
            {
                comentarioBuscado.Comentario = comentario.Comentario;

                _healthContext.Update(comentarioBuscado);

                _healthContext.SaveChanges();
            }
        }

        public Comentarios BuscarPorId(Guid id)
        {
            try
            {
                Comentarios search = _healthContext.Comentarios
               .Select(x => new Comentarios
               {
                   Id = x.Id,
                   Comentario = x.Comentario,
                   Exibe = x.Exibe,

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

        public void Cadastrar(Comentarios comentario)
        {
                comentario.Id = Guid.NewGuid();

                _healthContext.Comentarios.Add(comentario);

                _healthContext.SaveChanges();
        }

            public void Deletar(Guid id)
        {
            try
            {
                Comentarios comentarioDelete = _healthContext.Comentarios.Find(id);

                if (comentarioDelete != null)
                {
                    _healthContext.Remove(comentarioDelete);

                    _healthContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Comentarios> ListarPorPaciente()
        {
                return _healthContext.Comentarios.ToList();
        }
    }
}
