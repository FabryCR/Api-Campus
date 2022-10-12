namespace ApiCampus.Entities
{
    public class MatriculaObj
    {
        public int idMatricula { get; set; }
        public decimal MontoMatricula { get; set; }
        public int idEstudiante { get; set; }
        public int idCurso { get; set; }
        public DateTime fechaMatricula { get; set; }

        public string nombreEstudiante { get; set; } = string.Empty;
        public string cedulaEstudiante { get; set; } = string.Empty;
        public string nombreCurso { get; set; } = string.Empty;
    }
}
