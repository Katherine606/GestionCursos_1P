using Microsoft.AspNetCore.Mvc;
using GestionCursos.Models;
using GestionCursos.Services;


namespace GestionCursos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {

        private readonly CursoService _cursoService;

        public CursosController(CursoService cursoService)
        {
            _cursoService = cursoService;
        }

        private static List<Curso> cursos = new List<Curso>
        {
            new Curso{ Id = 1, Nombre = "Introducción GIT", Docente = "Celine Bravo", Activo = true},

        };

        //GET: http://localhost:5182/api/cursos
        //Obtener todos los cursos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cursoService.ObtenerCursos());
        }

        //GET: http://localhost:5182/api/cursos/1
        //Obtener curso por Id
        [HttpGet("{id}")]
        public IActionResult ObtenerCursoPorId(int id)
        {
            var curso = _cursoService.ObtenerCursoPorId(id);

            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        //POST: api/cursos FALTA service
        [HttpPost]
        public IActionResult Post([FromBody] Curso nuevoCurso)
        {
            nuevoCurso.Id = cursos.Count + 1;
            cursos.Add(nuevoCurso);

            return Created("", nuevoCurso);
        }

        //PUT: api/cursos/1 FALTA service
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Curso cursoActualizado)
        {
            var curso = cursos.FirstOrDefault(c => c.Id == id);

            if (curso == null)
            {
                return NotFound();
            }
            curso.Nombre = cursoActualizado.Nombre;
            curso.Docente = cursoActualizado.Docente;
            curso.Activo = cursoActualizado.Activo;

            return Ok(curso);

        }

        //DELETE: api/cursos/1 FALTA service
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var curso = cursos.FirstOrDefault(c => c.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            cursos.Remove(curso);

            return Ok(new { mensaje = "Curso eliminado correctamente" });
        }
    }
}