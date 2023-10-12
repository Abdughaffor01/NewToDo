using Domain;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;
public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> opt):base(opt)
    {
        Database.EnsureCreated();
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<ToDo> ToDos { get; set; }

}
