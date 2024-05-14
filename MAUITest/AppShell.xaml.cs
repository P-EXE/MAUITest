using MAUITest.Pages;
using MAUITest.ViewModels;

namespace MAUITest;

public partial class AppShell : Shell
{
  public AppShell()
  {
		InitializeComponent();

    Routing.RegisterRoute(nameof(ToDoListPage), typeof(ToDoListPage));
  }
}
