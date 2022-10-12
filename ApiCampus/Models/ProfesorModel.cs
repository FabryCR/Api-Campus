using ApiCampus.Entities;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ApiCampus.Models
{


    public class ProfesorModel
    {

            public List<ProfesorObj> ConsultarProfesores(IConfiguration _config)
                {
                    using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
                    {
                        var profesor = contexto.Query<ProfesorObj>("ConsultarProfesores", new { }, commandType: CommandType.StoredProcedure).ToList();
                        return profesor;
                    }
                 }

            public ProfesorObj ConsultarProfesor(IConfiguration _config, int idProfesor)
            {
                using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
                {
                    var profesor = contexto.Query<ProfesorObj>("ConsultarProfesor", new { idProfesor }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return (profesor != null ? profesor : new ProfesorObj());
                }
            }

            public ProfesorObj RegistrarProfesor(IConfiguration _config, ProfesorObj obj)
            {
                using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
                {
                    var profesor = contexto.Query<ProfesorObj>("RegistrarProfesor", new
                    {
                        obj.Cedula,
                        obj.Nombre,
                        obj.Apellido,
                        obj.Apellido2,
                        obj.Contraseña,
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return (profesor != null ? profesor : new ProfesorObj());
                }
            }

            public ProfesorObj ActualizarProfesor(IConfiguration _config, ProfesorObj obj)
            {
                using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
                {
                    var profesor = contexto.Query<ProfesorObj>("ActualizarProfesor", new
                    {
                        obj.IdProfesor,
                        obj.Cedula,
                        obj.Nombre,
                        obj.Apellido,
                        obj.Apellido2,
                        obj.Contraseña,
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return (profesor != null ? profesor : new ProfesorObj());
                }
            }

        public string EliminarProfesor(IConfiguration _config, int idProfesor)
        {
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var curso = contexto.Execute("EliminarProfesor", new
                {
                    idProfesor
                }, commandType: CommandType.StoredProcedure);

                return "Se eliminó correctamente";
            }
        }
    }
}
