using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITest.Models;

namespace MAUITest.ViewModels;

[QueryProperty("ToDo", "ToDo")]
public partial class CreateToDoVM : ObservableObject
{
  public CreateToDoVM()
  {

  }

  [ObservableProperty]
  private ToDoTask _todo;

  [RelayCommand]
  private async Task AddToDo()
  {
    // add todo to db
  }
}
