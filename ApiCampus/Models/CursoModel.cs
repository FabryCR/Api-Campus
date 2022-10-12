using ApiCampus.Entities;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;

namespace ApiCampus.Models
{
    public class CursoModel
    {
        public List<CursoObj> ConsultarCursos(IConfiguration _config)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var cursos = contexto.Query<CursoObj>("ConsultarCursos", new { }, commandType: CommandType.StoredProcedure).ToList();
                return cursos;
            }
        }

        public CursoObj ConsultarCurso(IConfiguration _config, int IDCurso)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var curso = contexto.Query<CursoObj>("ConsultarCurso", new { IDCurso }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return (curso != null ? curso : new CursoObj());
            }
        }

        public CursoObj RegistrarCurso(IConfiguration _config, CursoObj obj)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var curso = contexto.Query<CursoObj>("RegistrarCurso", new
                {
                    obj.nombre,
                    obj.creditos,
                    obj.carrera,
                    obj.idProfesor,
                    obj.cuposDisponibles,
                    obj.horario
                }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return (curso != null ? curso : new CursoObj());
            }
        }

        public CursoObj ActualizarCurso(IConfiguration _config, CursoObj obj)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var curso = contexto.Query<CursoObj>("ActualizarCurso", new
                {
                    obj.idCurso,
                    obj.nombre,
                    obj.creditos,
                    obj.carrera,
                    obj.idProfesor,
                    obj.cuposDisponibles,
                    obj.horario
                }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return (curso != null ? curso : new CursoObj());
            }
        }

        public string EliminarCurso(IConfiguration _config, int idCurso)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var curso = contexto.Execute("EliminarCurso", new 
                { 
                   idCurso 
                }, commandType: CommandType.StoredProcedure);

                return "Se eliminó correctamente";
            }
        }

        //Crea un SelectListItem para traer el nombre del profesor utilizando el id
        public List<SelectListItem> SelectListProfesor(IConfiguration _config)
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var profes = contexto.Query<ProfesorObj>("ConsultarProfesores", new { }, commandType: CommandType.StoredProcedure).ToList();

                foreach (var item in profes)
                {
                    lista.Add(new SelectListItem
                    {
                        Value = item.IdProfesor.ToString(),
                        Text = item.Nombre + ' ' + item.Apellido + ' ' + item.Apellido2
                    });
                }
                return lista;
            }
        }
    }
}
