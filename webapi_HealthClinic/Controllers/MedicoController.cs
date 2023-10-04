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
    public class MedicoController : ControllerBase
    {

        private IMedicoRepository _medicoRepository;


        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }



        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_medicoRepository.Listar());
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
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPatch]
        public IActionResult Patch(Guid id, Medico medico)
        {
            try
            {
                _medicoRepository.Atualizar(id, medico);

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
                _medicoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }
}
