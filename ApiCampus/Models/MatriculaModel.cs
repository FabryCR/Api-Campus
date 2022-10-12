using ApiCampus.Entities;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;

namespace ApiCampus.Models
{
    public class MatriculaModel
    {
        public List<MatriculaObj> ConsultarMatriculas(IConfiguration _config)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var Matriculas = contexto.Query<MatriculaObj>("ConsultarMatriculas", new { }, commandType: CommandType.StoredProcedure).ToList();
                return Matriculas;
            }
        }

        public MatriculaObj ConsultarMatricula(IConfiguration _config, int IDMatricula)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var Matricula = contexto.Query<MatriculaObj>("ConsultarMatricula", new { IDMatricula }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return (Matricula != null ? Matricula : new MatriculaObj());
            }
        }

        public MatriculaObj RegistrarMatricula(IConfiguration _config, MatriculaObj obj)
        {
            var fechaMatricula = DateTime.Now;
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var Matricula = contexto.Query<MatriculaObj>("RegistrarMatricula", new
                {
                    obj.MontoMatricula,
                    obj.idEstudiante,
                    obj.idCurso,
                    fechaMatricula

                }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return (Matricula != null ? Matricula : new MatriculaObj());
            }
        }

        public MatriculaObj ActualizarMatricula(IConfiguration _config, MatriculaObj obj)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var Matricula = contexto.Query<MatriculaObj>("ActualizarMatricula", new
                {
                    obj.idMatricula,
                    obj.MontoMatricula,
                    obj.idEstudiante,
                    obj.idCurso
                }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return (Matricula != null ? Matricula : new MatriculaObj());
            }
        }

        public string EliminarMatricula(IConfiguration _config, int idMatricula)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var curso = contexto.Execute("EliminarMatricula", new
                {
                    idMatricula
                }, commandType: CommandType.StoredProcedure);

                return "Se eliminó correctamente";
            }
        }

        //Crea un SelectListItem para traer la cédula del estudiante utilizando el id
        public List<SelectListItem> SelectListEstudiante(IConfiguration _config)
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var estudiantes = contexto.Query<EstudianteObj>("ConsultarEstudiantes", new { }, commandType: CommandType.StoredProcedure).ToList();

                foreach (var item in estudiantes)
                {
                    lista.Add(new SelectListItem
                    {
                        Value = item.idEstudiante.ToString(),
                        Text = item.Cedula
                    });
                }
                return lista;
            }
        }

        //Crea un SelectListItem para traer el nombre del curso y su horario utilizando el id
        public List<SelectListItem> SelectListCurso(IConfiguration _config)
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var cursos = contexto.Query<CursoObj>("ConsultarCursos", new { }, commandType: CommandType.StoredProcedure).ToList();

                foreach (var item in cursos)
                {
                    lista.Add(new SelectListItem
                    {
                        Value = item.idCurso.ToString(),
                        Text = item.nombre + " [ " + item.horario + "]"
                    });
                }
                return lista;
            }
        }



        //---------------------Matrícula Estudiante-------------------------

        public List<MatriculaObj> ConsultarMatriculasEstudiante(IConfiguration _config, string cedula)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var Matriculas = contexto.Query<MatriculaObj>("ConsultarMatriculasEstudiante", new { cedula }, commandType: CommandType.StoredProcedure).ToList();
                return Matriculas;
            }
        }
    }
}