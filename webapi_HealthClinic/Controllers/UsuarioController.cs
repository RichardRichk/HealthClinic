using Microsoft.AspNetCore.Authorization;
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
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository;


        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

                return Ok(_usuarioRepository.BuscarPorId(id));


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
                _usuarioRepository.Deletar(id);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }
}
