using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITest.Models;
using MAUITest.Pages;
using MAUITest.Services;
using System.Diagnostics;
using static MAUITest.ViewModels.ToDoDetailsVM;

namespace MAUITest.ViewModels;

public partial class ToDoListVM : ObservableObject
{
  private readonly IToDoService _toDoService;
  public ToDoListVM(IToDoService toDoService)
  {
    _toDoService = toDoService;
    Refresh();
  }

  [ObservableProperty]
  private bool _isRefreshing = false;
  [ObservableProperty]
  private IEnumerable<ToDoItem>? _toDos;
  [ObservableProperty]
  private ToDoItem? _selectedToDo;

  [ObservableProperty]
  private string[] _filters =
    [
      "Offen",
      "In Bearbeitung",
      "Abgeschlossen",
      "Alle"
    ];
  [ObservableProperty]
  private int _activeFilter;

  [RelayCommand]
  private async Task Refresh()
  {
    await GetToDos(ActiveFilter);
  }

  [RelayCommand]
  private async Task ChangeToDoStatus(ToDoItem todo)
  {
    todo.Status = Status.Done;
    await _toDoService.UpdateToDo(todo);
  }

  [RelayCommand]
  private async Task NavToToDo()
  {
    await Shell.Current.GoToAsync($"{nameof(ToDoDetailsPage)}", true, new Dictionary<string, object>
    {
      ["ToDo"] = SelectedToDo,
      ["Mode"] = PageMode.Edit
    });
    SelectedToDo = null;
  }

  private async Task GetToDos(int? value)
  {
    IsRefreshing = true;
    if (value >= 3 || value == null)
    {
      ToDos = await _toDoService.GetAllToDos();
    }
    else
    {
      ToDos = await _toDoService.GetToDoItemsByStatus((Status)value);
    }
    IsRefreshing = false;
  }

  async partial void OnActiveFilterChanged(int value)
  {
    await GetToDos(value);
  }
}
