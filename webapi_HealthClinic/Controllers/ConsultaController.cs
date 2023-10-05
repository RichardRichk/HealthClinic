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
    public class ConsultaController : ControllerBase
    {

        private IConsultaRepository _consultaRepository;


        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
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
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPatch]
        public IActionResult Patch(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);

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
                _consultaRepository.Deletar(id);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


    }
}
