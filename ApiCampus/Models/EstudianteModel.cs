using ApiCampus.Entities;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ApiCampus.Models
{
    public class EstudianteModel
    {


        public List<EstudianteObj> ConsultarEstudiantes(IConfiguration _config)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var estudiantes = contexto.Query<EstudianteObj>("ConsultarEstudiantes", new { }, commandType: CommandType.StoredProcedure).ToList();
                return estudiantes;
            }
        }

        public EstudianteObj ConsultarEstudiante(IConfiguration _config, int idEstudiante)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var estudiantes = contexto.Query<EstudianteObj>("ConsultarEstudiante", new { idEstudiante }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return (estudiantes != null ? estudiantes : new EstudianteObj());
            }
        }

        public EstudianteObj RegistrarEstudiante(IConfiguration _config, EstudianteObj obj)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var estudiantes = contexto.Query<EstudianteObj>("RegistrarEstudiante", new
                {
                    obj.Cedula,
                    obj.Nombre,
                    obj.Apellido1,
                    obj.Apellido2,
                    obj.contraseña,
                }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return (estudiantes != null ? estudiantes : new EstudianteObj());
            }
        }

        public EstudianteObj ActualizarEstudiante(IConfiguration _config, EstudianteObj obj)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var estudiantes = contexto.Query<EstudianteObj>("ActualizarEstudiante", new
                {
                    obj.idEstudiante,
                    obj.Cedula,
                    obj.Nombre,
                    obj.Apellido1,
                    obj.Apellido2,
                    obj.contraseña,
                }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return (estudiantes != null ? estudiantes : new EstudianteObj());
            }
        }

        public string EliminarEstudiante(IConfiguration _config, int idEstudiante)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var curso = contexto.Execute("EliminarEstudiante", new
                {
                    idEstudiante
                }, commandType: CommandType.StoredProcedure);

                return "Se eliminó correctamente";
            }
        }
    }
}
