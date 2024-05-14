using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITest.Models;
using MAUITest.Pages;
using MAUITest.Services;

namespace MAUITest.ViewModels;

[QueryProperty("ToDo", "ToDo")]
[QueryProperty("Mode", "Mode")]
public partial class ToDoDetailsVM : ObservableObject
{
  private readonly IToDoService _toDoService;
  public ToDoDetailsVM(IToDoService toDoService)
  {
    _toDoService = toDoService;
    ToDo = new();
  }

  [ObservableProperty]
  private PageMode _mode;

  [ObservableProperty]
  private bool _available = true;

  [ObservableProperty]
  private ToDoItem? _toDo;

  [ObservableProperty]
  private string[] _statusTypes =
    [
      "Offen",
      "In Bearbeitung",
      "Abgeschlossen",
    ];
  [ObservableProperty]
  private int _selectedStatus;

  [RelayCommand]
  private async Task SaveToDo()
  {
    switch (Mode)
    {
      case PageMode.New:
        {
          await AddToDo();
          break;
        }
      case PageMode.Edit:
        {
          await UpdateToDo();
          break;
        }
    }
  }

  private async Task AddToDo()
  {
    Available = false;
    bool success = false;

    try
    {
      ToDoItem todo = new()
      {
        Id = new Guid(),
        Title = ToDo.Title,
        Description = ToDo.Description,
        Due = ToDo.Due,
        Status = (Status)SelectedStatus
      };
      success = await _toDoService.AddToDo(todo);
    }
    catch (Exception ex)
    {
      Available = true;
      return;
    }

    ToDo = new();
    Available = true;

    if (!success)
    { return; }
    await Shell.Current.GoToAsync($"//{nameof(ToDoListPage)}");
  }

  private async Task UpdateToDo()
  {
    Available = false;
    bool success = false;
    try
    {
      ToDoItem? todo = ToDo;
      todo.Status = (Status)SelectedStatus;
      await _toDoService.UpdateToDo(ToDo);
      success = true;
    }
    catch (Exception ex)
    {

    }
    Available = true;
    await Shell.Current.GoToAsync($"//{nameof(ToDoListPage)}");
  }

  [RelayCommand]
  private async Task DeleteToDo()
  {
    Available = false;
    bool success = false;

    try
    {
      await _toDoService.DeleteToDo(ToDo);
      success = true;
      await Shell.Current.GoToAsync($"//{nameof(ToDoListPage)}");
    }
    catch (Exception ex)
    {

    }
    Available = true;
  }

  public enum PageMode
  {
    New,
    Edit
  }
}
