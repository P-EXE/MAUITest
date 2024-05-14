using MAUITest.Pages;

namespace MAUITest;

public partial class AppShell : Shell
{
  public AppShell()
  {
    InitializeComponent();

    Routing.RegisterRoute(nameof(ToDoListPage), typeof(ToDoListPage));
    Routing.RegisterRoute(nameof(CreateToDoPage), typeof(CreateToDoPage));
  }
}
