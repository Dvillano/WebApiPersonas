using Microsoft.EntityFrameworkCore;
using SWMedicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWMedicos.Data
{
    public class MedicoDbContext : DbContext
    {
        public MedicoDbContext(DbContextOptions<MedicoDbContext> options) : base(options) { }
        public DbSet<Medico> Medico { get; set; }
    }
}
