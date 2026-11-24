using GestionCursos.Models;
namespace GestionCursos.Services
{
    public class CursoService
    {
        //Lista Cursos
        private static List<Curso> cursos = new List<Curso>
        {
            new Curso{ Id = 1, Nombre = "Programación", Docente = "Paola Bravo", Activo = true},
            new Curso{ Id = 2, Nombre = "Diseño Móvil", Docente = "Lissette Puya", Activo = false},
        };

        //Obtener todos los cursos
        public List<Curso> ObtenerCursos()
        {
            return cursos;
        }

        //Obtener curso por Id
        public Curso? ObtenerCursoPorId(int id)
        {
            return cursos.FirstOrDefault(c => c.Id == id);
        }
    }   
}