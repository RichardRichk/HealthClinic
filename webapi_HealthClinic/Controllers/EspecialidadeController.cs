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
    public class EspecialidadeController : ControllerBase
    {

        private IEspecialidadeRepository _especialidadeRepository;


        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_especialidadeRepository.Listar());
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
                return Ok(_especialidadeRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Especialidades especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete]
        public IActionResult Delete(Guid id)
        {

            try
            {
                _especialidadeRepository.Deletar(id);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }
}
