namespace MAUITest;

public partial class TaskDetailPage : ContentPage
{
    private readonly TaskDatabase _database;
    private TaskItem _taskItem;

    public TaskDetailPage(TaskDatabase database, TaskItem taskItem)
    {
        InitializeComponent();
        _database = database;
        _taskItem = taskItem;
        BindingContext = _taskItem;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        _taskItem.Title = titleEntry.Text;
        _taskItem.Description = descriptionEntry.Text;
        _taskItem.DueDate = dueDatePicker.Date;
        _taskItem.Status = statusPicker.SelectedItem.ToString();

        await _database.SaveTaskAsync(_taskItem);
        await Navigation.PopAsync();
    }
}