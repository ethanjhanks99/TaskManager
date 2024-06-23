namespace TaskManager.Models
{
  public class TaskObj
  {
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
  }
}