using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models
{
  public class TaskObj
  {
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }

    // Foreign Key
    public int? FolderId { get; set;}
    public Folder? Folder { get; set; }
  }
}