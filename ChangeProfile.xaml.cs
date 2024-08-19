using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Storage; // Для использования Preferences

namespace AC
{
    public partial class ChangeProfile : ContentPage
    {
        private readonly UserService _userService;

        public ChangeProfile()
        {
            InitializeComponent();
            _userService = new UserService();
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
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            
                await DisplayAlert("Успех", "Профиль успешно обновлён", "OK");
            await Navigation.PushAsync(new Profile());
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
