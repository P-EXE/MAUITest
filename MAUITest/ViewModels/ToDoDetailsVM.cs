using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITest.Models;
using MAUITest.Pages;
using MAUITest.Services;

namespace MAUITest.ViewModels;

[QueryProperty("ToDo", "ToDo")]
public partial class ToDoDetailsVM : ObservableObject
{
  private readonly IToDoService _toDoService;
  public ToDoDetailsVM(IToDoService toDoService)
  {
    _toDoService = toDoService;
    ToDo = new();
  }

  [ObservableProperty]
  private bool _available = true;

  [ObservableProperty]
  private ToDoTask? _toDo;

  [ObservableProperty]
  private string[] _statusTypes =
    [
      "Offen",
      "In Bearbeitung",
      "Abgeschlossen"
    ];

  [RelayCommand]
  private async Task AddToDo()
  {
    Available = false;
    bool success = false;

    try
    {
      ToDoTask todo = new()
      {
        Title = ToDo.Title,
        Description = ToDo.Description,
        Due = ToDo.Due,
        Status = ToDo.Status
      };
    }
    catch (Exception ex)
    {
      Available = true;
      return;
    }

    success = await _toDoService.AddToDo(ToDo);
    Available = true;

    if (!success)
    { return; }
    await Shell.Current.GoToAsync($"//{nameof(ToDoListPage)}");
  }
}
