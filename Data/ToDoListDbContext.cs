using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data;

public class ToDoListDbContext : DbContext
{
    public ToDoListDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ToDoListItem> Specials { get; set; }
}    