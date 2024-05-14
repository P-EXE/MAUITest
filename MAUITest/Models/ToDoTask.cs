namespace MAUITest.Models;

public class ToDoTask
{
  public Guid Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public DateTime Due { get; set; }
  public Status Status { get; set;}
}

public enum Status
{
  Open,
  InProgress,
  Done
}