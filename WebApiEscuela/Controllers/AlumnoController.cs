using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiEscuela.Data;
using WebApiEscuela.Models;

namespace WebApiEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        
        private readonly ApplicationDbContext context;
        public AlumnoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Traer todos los alumnos
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return context.Alumno.ToList();
        }

        //Traer alumno por id
        [HttpGet("{id}")]
        public ActionResult<Alumno> Get(int id)
        {
            return context.Alumno.Find(id);
        }

        //Insertar alumno
        [HttpPost]
        public ActionResult Post(Alumno alumno)
        {
            context.Alumno.Add(alumno);
            context.SaveChanges();
            return Ok();
        }

        //Modificar alumno
        [HttpPut("{id}")]
        public ActionResult Put(int id, Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }
            context.Entry(alumno).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //Eliminar alumno
        [HttpDelete("{id}")]
        public ActionResult<Alumno> Delete(int id)
        {
            Alumno alumno = context.Alumno.Find(id);

            if (alumno == null)
            {
                return NotFound();
            }

            context.Alumno.Remove(alumno);
            context.SaveChanges();
            return alumno;
        }

        //Traer alumno por matricula
        [HttpGet("matricula/{matricula}")]
        public IEnumerable<Alumno> GetByEspecialidad(int matricula)
        {
            var alumnos = (from a in context.Alumno
                            where a.Matricula == matricula
                            select a).ToList();

            return alumnos;
        }

        //Traer alumno por ciudad
        [HttpGet("ciudad/{ciudad}")]
        public IEnumerable<Alumno> GetByCiudad(string ciudad)
        {
            var alumnos = (from a in context.Alumno
                            where a.Ciudad == ciudad
                            select a).ToList();

            return alumnos;
        }
   
    }
}
