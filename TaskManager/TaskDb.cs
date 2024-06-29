using TaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Data
{
  public class TaskDb : DbContext
  {
    public TaskDb(DbContextOptions options) : base(options) { }
    public DbSet<TaskObj> Tasks { get; set; }
    public DbSet<Folder> Folders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=taskmanager.db");
    }
    
  }
}