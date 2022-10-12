using ApiCampus.Entities;
using ApiCampus.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCampus.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IConfiguration _config;
        AuthModel model = new AuthModel();

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost /*Authorize*/]
        [Route("Login")]
        public ActionResult<UsuarioObj> Login([FromBody] UsuarioObj obj)
        {
            try
            {
                return Ok(model.AuthCheck(_config, obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
