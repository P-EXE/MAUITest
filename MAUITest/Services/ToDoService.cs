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

  public async Task<bool> AddToDo(ToDoItem todo)
  {
    bool success = false;
    try
    {
      _context.ToDoItems.Add(todo);
      _context.SaveChanges();
      success = true;
    }
    catch (Exception ex)
    {

    }
    return success;
  }

  public async Task DeleteToDo(Guid todoId)
  {
    _context.Remove(todoId);
    await _context.SaveChangesAsync();
  }

  public async Task<IEnumerable<ToDoItem>>? GetAllToDos()
  {
    IEnumerable<ToDoItem>? todos;
    todos = _context.ToDoItems
      .Where(t => t.Id != null)
      .AsEnumerable();
    return todos;
  }

  public async Task<IEnumerable<ToDoItem>>? GetToDoItemsByStatus(Status status)
  {
    if (status.Equals(3))
    {
      return await GetAllToDos();
    }
    IEnumerable<ToDoItem>? todos;
    todos = _context.ToDoItems
      .Where(t => t.Status == status)
      .AsEnumerable();
    return todos;
  }

  public async Task UpdateToDo(ToDoItem todo)
  {
    _context.ToDoItems.Update(todo);
    await _context.SaveChangesAsync();
  }
}
