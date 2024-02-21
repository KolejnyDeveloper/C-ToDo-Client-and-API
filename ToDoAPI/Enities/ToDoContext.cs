using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ToDoAPI.Enities
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        
        }

        public DbSet<ToDoItem> ToDoTasks { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ToDoDb;Trusted_Connection=True");
        }
        */
    }
}
