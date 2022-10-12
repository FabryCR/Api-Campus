using ApiCampus.Entities;
using ApiCampus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApiCampus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private IConfiguration _config;
        CursoModel mod = new CursoModel();

        public CursoController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet /*Authorize*/]
        [Route("ConsultarCursos")]
        public ActionResult<List<CursoObj>> ConsultarCursos()
        {
            try
            {
                return Ok(mod.ConsultarCursos(_config));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet /*Authorize*/]
        [Route("ConsultarCurso")]
        public ActionResult<CursoObj> ConsultarCurso(int idCurso)
        {
            try
            {
                return Ok(mod.ConsultarCurso(_config, idCurso));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost /*Authorize*/]
        [Route("RegistrarCurso")]
        public ActionResult<CursoObj> RegistrarCurso([FromBody] CursoObj obj)
        {
            try
            {
                return Ok(mod.RegistrarCurso(_config, obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, /*Authorize*/]
        [Route("ActualizarCurso")]
        public ActionResult ActualizarCurso([FromBody] CursoObj obj)
        {
            try
            {
                return Ok(mod.ActualizarCurso(_config, obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, /*Authorize*/]
        [Route("EliminarCurso")]
        public ActionResult EliminarCurso(int id)
        {
            try
            {
                return Ok(mod.EliminarCurso(_config, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet /*Authorize*/]
        [Route("SelectListProfesores")]
        public ActionResult<List<SelectListItem>> SelectListProfesores()
        {
            try
            {
                return Ok(mod.SelectListProfesor(_config));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
