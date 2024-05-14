namespace MAUITest;

public partial class CompletedTasksPage : ContentPage
{
    private readonly TaskDatabase _database;

    public CompletedTasksPage()
    {
        InitializeComponent();
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskDatabase.db3");
        _database = new TaskDatabase(dbPath);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var tasks = await _database.GetTasksAsync();
        CompletedTasksCollectionView.ItemsSource = tasks.Where(task => task.Status == "Completed").ToList();
    }
}