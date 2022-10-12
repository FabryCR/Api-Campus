using ApiCampus.Entities;
using ApiCampus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApiCampus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private IConfiguration _config;
        MatriculaModel mod = new MatriculaModel();


        public MatriculaController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet /*Authorize*/]
        [Route("ConsultarMatriculas")]
        public ActionResult<List<MatriculaObj>> ConsultarMatriculas()
        {
            try
            {
                return Ok(mod.ConsultarMatriculas(_config));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet /*Authorize*/]
        [Route("ConsultarMatricula")]
        public ActionResult<MatriculaObj> ConsultarMatricula(int idMatricula)
        {
            try
            {
                return Ok(mod.ConsultarMatricula(_config, idMatricula));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost /*Authorize*/]
        [Route("RegistrarMatricula")]
        public ActionResult<MatriculaObj> RegistrarMatricula([FromBody] MatriculaObj obj)
        {
            try
            {
                return Ok(mod.RegistrarMatricula(_config, obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, /*Authorize*/]
        [Route("ActualizarMatricula")]
        public ActionResult ActualizarMatricula([FromBody] MatriculaObj obj)
        {
            try
            {
                return Ok(mod.ActualizarMatricula(_config, obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, /*Authorize*/]
        [Route("EliminarMatricula")]
        public ActionResult EliminarMatricula(int id)
        {
            try
            {
                return Ok(mod.EliminarMatricula(_config, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet /*Authorize*/]
        [Route("SelectListEstudiante")]
        public ActionResult<List<SelectListItem>> SelectListEstudiante()
        {
            try
            {
                return Ok(mod.SelectListEstudiante(_config));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet /*Authorize*/]
        [Route("SelectListCurso")]
        public ActionResult<List<SelectListItem>> SelectListCurso()
        {
            try
            {
                return Ok(mod.SelectListCurso(_config));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //---------------------Matrícula Estudiante-------------------------

        [HttpGet /*Authorize*/]
        [Route("ConsultarMatriculasEstudiante")]
        public ActionResult<List<MatriculaObj>> ConsultarMatriculasEstudiante(string cedula)
        {
            try
            {
                return Ok(mod.ConsultarMatriculasEstudiante(_config, cedula));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

