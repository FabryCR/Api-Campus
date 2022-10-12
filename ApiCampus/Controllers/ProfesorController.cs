using ApiCampus.Entities;
using ApiCampus.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCampus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {

        private IConfiguration _config;
        ProfesorModel mod = new ProfesorModel();
        public ProfesorController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet /*Authorize*/]
        [Route("ConsultarProfesores")]
        public ActionResult<List<ProfesorObj>> ConsultarProfesores()
        {
            try
            {
                return Ok(mod.ConsultarProfesores(_config));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet /*Authorize*/]
        [Route("ConsultarProfesor")]
        public ActionResult<ProfesorObj> ConsultarProfesor(int idProfesor)
        {
            try
            {
                return Ok(mod.ConsultarProfesor(_config, idProfesor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost /*Authorize*/]
        [Route("RegistrarProfesor")]
        public ActionResult<ProfesorObj> RegistrarProfesor([FromBody] ProfesorObj obj)
        {
            try
            {
                return Ok(mod.RegistrarProfesor(_config, obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, /*Authorize*/]
        [Route("ActualizarProfesor")]
        public ActionResult ActualizarProfesor([FromBody] ProfesorObj obj)
        {
            try
            {
                return Ok(mod.ActualizarProfesor(_config, obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, /*Authorize*/]
        [Route("EliminarProfesor")]
        public ActionResult EliminarProfesor(int id)
        {
            try
            {
                return Ok(mod.EliminarProfesor(_config, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
