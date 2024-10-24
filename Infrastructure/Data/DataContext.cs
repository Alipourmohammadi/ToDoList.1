using Microsoft.EntityFrameworkCore;
using ToDoList.Core.Entities;

namespace Infrastructure.Dat
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
