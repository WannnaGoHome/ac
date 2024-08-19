namespace AC
{
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }

        private async void OnStatisticsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Statistics());
        }

        private async void OnDesktopClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Desktop());
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }

        private async void OnEditProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangeProfile());
        }

        private async void OnLogOutClicked(object sender, EventArgs e)
        {
            Preferences.Clear(); // Clear user preferences
            await Navigation.PushAsync(new StartPage()); // Redirect to login page
        }
    }
}
