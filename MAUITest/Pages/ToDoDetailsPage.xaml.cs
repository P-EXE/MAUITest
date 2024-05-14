using MAUITest.ViewModels;

namespace MAUITest.Pages;

public partial class ToDoDetailsPage : ContentPage
{
	private readonly ToDoDetailsVM _vm;
	public ToDoDetailsPage(ToDoDetailsVM vm)
	{
		_vm = vm;
		BindingContext = _vm;
		InitializeComponent();
	}
}