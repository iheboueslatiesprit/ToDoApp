using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp
{
    public class APIDbContext : DbContext

    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }
        public DbSet<TodoItem> ToDoItems
        {
            get;
            set;
        
        }
    }
}
