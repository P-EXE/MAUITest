using MAUITest;
namespace MAUITest;

public partial class TaskEntryPage : ContentPage
{
    private readonly TaskDatabase _database;

    public TaskEntryPage(TaskDatabase database)
    {
        InitializeComponent();
        _database = database;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        try
        {
            var taskItem = new TaskItem
            {
                Title = titleEntry.Text,
                Description = descriptionEntry.Text,
                DueDate = dueDatePicker.Date,
                Status = statusPicker.SelectedItem.ToString()
            };

            await _database.SaveTaskAsync(taskItem);
            await Navigation.PopAsync();
        }
        catch (Exception)
        {
            DisplayAlert("Status Error","You have to select a Task status","OK");
        }
    }
}