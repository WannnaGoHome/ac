namespace AC;

using Microsoft.Maui.Controls;

public partial class Statistics : ContentPage
{
    public Statistics()
    {
        InitializeComponent();
        LoadStatistics();
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

    private void LoadStatistics()
    {
        // Загрузите статистику и обновите отображение
        // Например, загрузите и покажите графики
    }
}
