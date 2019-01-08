using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace SubordinatesTree.Models
{
    public class PersonContextFactory: IDesignTimeDbContextFactory<PersonContext>
    {
        public PersonContext CreateDbContext (string[] args)
        {
            DbContextOptionsBuilder<PersonContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<PersonContext>();
            DbContextOptions<PersonContext> options = dbContextOptionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = personsdb; Trusted_Connection = True;").Options;
            return new PersonContext(options);
        }
    }
}
