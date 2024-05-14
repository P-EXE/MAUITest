using MAUITest.ViewModels;

namespace MAUITest.Pages;

public partial class CreateToDoPage : ContentPage
{
	private readonly CreateToDoVM _vm;
	public CreateToDoPage(CreateToDoVM vm)
	{
		_vm = vm;
		BindingContext = _vm;
		InitializeComponent();
	}
}