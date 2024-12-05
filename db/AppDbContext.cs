using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;


namespace ToDoAPI.Db{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}