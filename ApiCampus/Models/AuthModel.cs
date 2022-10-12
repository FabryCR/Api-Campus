using ApiCampus.Entities;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ApiCampus.Models
{
    public class AuthModel
    {
        public UsuarioObj AuthCheck(IConfiguration _config, UsuarioObj user)
        {
            //Check Profesor
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var userResponse = contexto.Query<ProfesorObj>("ConsultarLogin", new { user.cedula, isAdmin = true }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (userResponse != null)
                {
                    if (user.contraseña == userResponse.Contraseña)
                    {
                        user.cedula = userResponse.Cedula;
                        user.Nombre = userResponse.Nombre;
                        user.Apellido1 = userResponse.Apellido;
                        user.Apellido2 = userResponse.Apellido2;
                        user.rol = "Profesor";

                        return user;
                    }
                    user.contraseña = "La contraseña es incorrecta";
                    return user;
                }
            }

            //Check Estudiante
            using (var contexto = new SqlConnection(_config.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var userResponse = contexto.Query<EstudianteObj>("ConsultarLogin", new { user.cedula, isAdmin = false }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (userResponse != null)
                {
                    if (user.contraseña == userResponse.contraseña)
                    {
                        user.cedula = userResponse.Cedula;
                        user.Nombre = userResponse.Nombre;
                        user.Apellido1 = userResponse.Apellido1;
                        user.Apellido2 = userResponse.Apellido2;
                        user.rol = "Estudiante";

                        return user;
                    }
                    user.contraseña = "La contraseña es incorrecta";
                    return user;
                }
            }
            
            user.cedula = "El usuario No existe";
            return user;
        }
    }
}
