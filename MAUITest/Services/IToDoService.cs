using MAUITest.Models;

namespace MAUITest.Services;

public interface IToDoService
{
  Task<bool> AddToDo(ToDoItem todo);
  Task<IEnumerable<ToDoItem>>? GetAllToDos();
  Task UpdateToDo(ToDoItem todo);
  Task DeleteToDo(ToDoItem todoId);
  Task<IEnumerable<ToDoItem>>? GetToDoItemsByStatus(Status status);
}
