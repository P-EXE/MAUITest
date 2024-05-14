using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITest.Models;
using MAUITest.Pages;
using MAUITest.Services;
using System.Diagnostics;

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
  private IEnumerable<ToDoTask>? _toDos;
  [ObservableProperty]
  private ToDoTask? _selectedToDo;

  [RelayCommand]
  private async Task Refresh()
  {
    IsRefreshing = true;
    ToDos = await _toDoService.GetAllToDos();
    IsRefreshing = false;
  }

  [RelayCommand]
  private async Task ChangeToDoStatus(int param)
  {
    Debug.WriteLine(param);
  }

  [RelayCommand]
  private async Task NavToToDo()
  {
    await Shell.Current.GoToAsync($"{nameof(ToDoDetailsPage)}", true, new Dictionary<string, object>
    {
      ["ToDo"] = SelectedToDo
    });
    SelectedToDo = null;
  }
}
