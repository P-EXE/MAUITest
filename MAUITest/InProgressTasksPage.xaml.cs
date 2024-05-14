namespace MAUITest;

public partial class InProgressTasksPage : ContentPage
{
    private readonly TaskDatabase _database;

    public InProgressTasksPage()
    {
        InitializeComponent();
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskDatabase.db3");
        _database = new TaskDatabase(dbPath);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var tasks = await _database.GetTasksAsync();
        InProgressTasksCollectionView.ItemsSource = tasks.Where(task => task.Status == "In Progress").ToList();
    }
}