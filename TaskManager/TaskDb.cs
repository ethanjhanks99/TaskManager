using TaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Data
{
  public class TaskDb : DbContext
  {
    public TaskDb(DbContextOptions options) : base(options) { }
    public DbSet<TaskObj> Tasks { get; set; }
  }
}