using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SWAlumnos.Models;

namespace SWAlumnos.Data
{
    public class AlumnoDbContext : DbContext
    {
        public AlumnoDbContext(DbContextOptions<AlumnoDbContext> options) : base(options) { }
        public DbSet<Alumno> Alumno { get; set; }
    }
}
