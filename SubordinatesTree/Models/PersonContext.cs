using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SubordinatesTree.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<PersonModel> Persons { get; set; }
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<PersonModel>().HasKey(c => c.PersonId);
            modelBuilder.Entity<PersonModel>().Property(c => c.PersonId).ValueGeneratedNever();
        }
    }
}
