using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models
{
  public class Folder
  {
    public int FolderId { get; set; }
    public required string Title { get; set; }
    public ICollection<TaskObj> Tasks { get; } = new List<TaskObj>();
  }
}