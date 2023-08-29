using Microsoft.EntityFrameworkCore;
using todoapi.Models;

namespace todoapi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
        
        
    }
}