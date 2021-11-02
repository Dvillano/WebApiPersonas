using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWMedicos.Data;
using SWMedicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWMedicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoDbContext context;
        public MedicoController(MedicoDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Medico> Get()
        {
            return context.Medico.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Medico> Get(int id)
        {
            return context.Medico.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Medico medico)
        {
            context.Medico.Add(medico);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Medico medico)
        {
            if (id != medico.Id)
            {
                return BadRequest();
            }
            context.Entry(medico).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Medico> Delete(int id)
        {
            Medico medico = context.Medico.Find(id);

            if (medico == null)
            {
                return NotFound();
            }

            context.Medico.Remove(medico);
            context.SaveChanges();
            return medico;
        }
    }
}
