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
    public class ProfesorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProfesorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Traer todos los profesores
        [HttpGet]
        public IEnumerable<Profesor> Get()
        {
            return context.Profesor.ToList();
        }

        //Traer profesor por id
        [HttpGet("{id}")]
        public ActionResult<Profesor> Get(int id)
        {
            return context.Profesor.Find(id);
        }

        //Insertar profesor
        [HttpPost]
        public ActionResult Post(Profesor profesor)
        {
            context.Profesor.Add(profesor);
            context.SaveChanges();
            return Ok();
        }

        //Modificar profesor
        [HttpPut("{id}")]
        public ActionResult Put(int id, Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }
            context.Entry(profesor).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //Eliminar profesor
        [HttpDelete("{id}")]
        public ActionResult<Profesor> Delete(int id)
        {
            Profesor profesor = context.Profesor.Find(id);

            if (profesor == null)
            {
                return NotFound();
            }

            context.Profesor.Remove(profesor);
            context.SaveChanges();
            return profesor;
        }

        //Traer profesor por titutlo
        [HttpGet("titulo/{titulo}")]
        public IEnumerable<Profesor> GetByTitulo(string titulo)
        {
            var profesores = (from p in context.Profesor
                           where p.Titulo == titulo
                           select p).ToList();

            return profesores;
        }
    }
}
