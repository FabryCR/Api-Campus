using ApiCampus.Entities;
using ApiCampus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCampus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {

        private IConfiguration _config;
        EstudianteModel mod = new EstudianteModel();


        public EstudianteController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet /*Authorize*/]
        [Route("ConsultarEstudiantes")]
        public ActionResult<List<EstudianteObj>> ConsultarEstudiantes()
        {
            try
            {
                return Ok(mod.ConsultarEstudiantes(_config));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet /*Authorize*/]
        [Route("ConsultarEstudiante")]
        public ActionResult<EstudianteObj> ConsultarEstudiante(int idEstudiante)
        {
            try
            {
                return Ok(mod.ConsultarEstudiante(_config, idEstudiante));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost /*Authorize*/]
        [Route("RegistrarEstudiante")]
        public ActionResult<EstudianteObj> RegistrarEstudiante([FromBody] EstudianteObj obj)
        {
            try
            {
                return Ok(mod.RegistrarEstudiante(_config, obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, /*Authorize*/]
        [Route("ActualizarEstudiante")]
        public ActionResult ActualizarEstudiante([FromBody] EstudianteObj obj)
        {
            try
            {
                return Ok(mod.ActualizarEstudiante(_config, obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, /*Authorize*/]
        [Route("EliminarEstudiante")]
        public ActionResult EliminarEstudiante(int id)
        {
            try
            {
                return Ok(mod.EliminarEstudiante(_config, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
