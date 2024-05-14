using MAUITest.ViewModels;

namespace MAUITest.Pages;

public partial class ToDoListPage : ContentPage
{
	private readonly ToDoListVM _vm;
	public ToDoListPage(ToDoListVM vm)
	{
		_vm = vm;
		BindingContext = _vm;
		InitializeComponent();
	}
}