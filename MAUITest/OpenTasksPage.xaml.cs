namespace MAUITest
{
    public partial class OpenTasksPage : ContentPage {

        private readonly TaskDatabase _database;

        public OpenTasksPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskDatabase.db3");
            _database = new TaskDatabase(dbPath);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var tasks = await _database.GetTasksAsync();
            OpenTasksCollectionView.ItemsSource = tasks.Where(task => task.Status == "Open").ToList();
        }
    }
}