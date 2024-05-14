using MAUITest.DataContext;
using MAUITest.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUITest.Services;

public class ToDoService : IToDoService
{
  private readonly LocalDBContext _context;
  public ToDoService(LocalDBContext context)
  {
    _context = context;
  }

  public async Task<bool> AddToDo(ToDoTask todo)
  {
    bool success = false;
    try
    {
      _context.ToDoTasks.Add(todo);
      _context.SaveChanges();
      success = true;
    }
    catch (Exception ex)
    {

    }
    return success;
  }

  public async Task<IEnumerable<ToDoTask>>? GetAllToDos()
  {
    IEnumerable<ToDoTask>? todos;
    todos = _context.ToDoTasks
      .Where(t => t.Id != null)
      .AsEnumerable();
    return todos;
  }
}
