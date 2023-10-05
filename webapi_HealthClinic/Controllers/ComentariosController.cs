using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_HealthClinic.Domains;
using webapi_HealthClinic.Interfaces;
using webapi_HealthClinic.Repositoryes;

namespace webapi_HealthClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosController : ControllerBase
    {

        private IComentariosRepository _comentariosRepository;


        public ComentariosController()
        {
            _comentariosRepository = new ComentariosRepository();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_comentariosRepository.ListarPorPaciente());
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_comentariosRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Comentarios comentarios)
        {
            try
            {
                _comentariosRepository.Cadastrar(comentarios);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPatch]
        public IActionResult Patch(Guid id, Comentarios comentarios)
        {
            try
            {
                _comentariosRepository.Atualizar(id, comentarios);

                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }



        [HttpDelete]
        public IActionResult Delete(Guid id)
        {

            try
            {
                _comentariosRepository.Deletar(id);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }
}
