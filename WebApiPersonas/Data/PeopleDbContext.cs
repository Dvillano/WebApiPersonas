using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using WebApiPersonas.Models;

namespace WebApiPersonas.Data
{
    public class PeopleDbContext : DbContext
    {
        //Tene que estar el constructor con parametros en Core
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }

    }
}
