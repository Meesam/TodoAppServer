using Microsoft.EntityFrameworkCore;
using TodoAppServer.Models;

namespace TodoAppServer.Data
{
    public class TodoAppDbContext:DbContext
    {
        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options):base(options) { }

        public DbSet<Todo> Todos { get; set; }
    }
}
