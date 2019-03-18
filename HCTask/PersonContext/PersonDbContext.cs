using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCTask.Models;

namespace HCTask.PersonContext
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
        
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
