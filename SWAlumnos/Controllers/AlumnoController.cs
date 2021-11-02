using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAlumnos.Data;
using SWAlumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly AlumnoDbContext context;
        public AlumnoController(AlumnoDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return context.Alumno.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Alumno> Get(int id)
        {
            return context.Alumno.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Alumno alumno)
        {
            context.Alumno.Add(alumno);
            context.SaveChanges();
            return Ok();
        }

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
