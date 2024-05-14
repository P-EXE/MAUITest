﻿namespace MAUITest
{
    public partial class MainPage : ContentPage
    {
        private readonly TaskDatabase _database;

        public MainPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskDatabase.db3");
            _database = new TaskDatabase(dbPath);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TasksCollectionView.ItemsSource = await _database.GetTasksAsync();
        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskEntryPage(_database));
        }
    }
}