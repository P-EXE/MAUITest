using MAUITest.Models;

namespace MAUITest.Services;

public interface IToDoService
{
  Task<bool> AddToDo(ToDoTask todo);
  Task<IEnumerable<ToDoTask>>? GetAllToDos();
}
