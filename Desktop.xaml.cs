namespace AC;

public partial class Desktop : ContentPage
{
	public Desktop()
	{
		InitializeComponent();
	}

    private async void OnLessonButtonClicked(object sender, EventArgs e)
    {

        // Переход на ScanWindow с передачей ID урока
        await Navigation.PushAsync(new ScanWindow());
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


}