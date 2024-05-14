using System.Windows.Input;

namespace MAUITest
{
    public partial class MainPage : ContentPage
    {
        private readonly TaskDatabase _database;

        public MainPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskDatabase.db3");
            _database = new TaskDatabase(dbPath);
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TasksCollectionView.ItemsSource = await _database.GetTasksAsync();
        }

        public ICommand EditTaskCommand => new Command<TaskItem>(async (task) =>
        {
            await Navigation.PushAsync(new TaskDetailPage(_database, task));
        });

        public ICommand DeleteTaskCommand => new Command<TaskItem>(async (task) =>
        {
            bool confirm = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete the task '{task.Title}'?", "Yes", "No");
            if (confirm)
            {
                await _database.DeleteTaskAsync(task);
                TasksCollectionView.ItemsSource = await _database.GetTasksAsync();
            }
        });

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskEntryPage(_database));
        }
    }
}
