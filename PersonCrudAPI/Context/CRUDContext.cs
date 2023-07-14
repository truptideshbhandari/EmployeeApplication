using Microsoft.EntityFrameworkCore;
using PersonCrudAPI.Models;

namespace PersonCrudAPI.Context
{
    public class CRUDContext:DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}
