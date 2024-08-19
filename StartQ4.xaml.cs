namespace AC;

public partial class StartQ4 : ContentPage
{
    public StartQ4()
    {
        InitializeComponent();
    }

    private async void OnStartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Desktop());
    }
    private async void GoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    var userService = new UserService();
    //    var userUIN = Preferences.Get("UserUIN", string.Empty);
    //    var currentUser = await userService.GetUserByUINAsync(userUIN);

    //    if (currentUser != null)
    //    {
    //        await DisplayAlert("Успех", "Вход прошёл успешно!", "OK");
    //        await Navigation.PushAsync(new Desktop());
    //    }
    //    else
    //    {
    //        await DisplayAlert("Ошибка", "Пользователь не найден", "OK");
    //    }
    //}
}
