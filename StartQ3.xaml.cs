namespace AC;

public partial class StartQ3 : ContentPage
{
    private string _role;
    private string _lastName;
    private string _firstName;
    private string _patronymic;
    public StartQ3(string role, string lastName, string firstName, string patronymic)
    {
        InitializeComponent();
        _role = role;
        _lastName = lastName;
        _firstName = firstName;
        _patronymic = patronymic;

        // Заполните поля данными, если это необходимо
        //lastName.Text = _lastName;
        //firstName.Text = _firstName;
        //patronymic.Text = _patronymic;
    }

    private async void GoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnContinueClicked(object sender, EventArgs e)
    {
        string uin = uinEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(uin) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля.", "OK");
            return;
        }

        var userService = new UserService();
        var existingUser = await userService.GetUserByUINAsync(uin);

        if (existingUser != null)
        {
            if (existingUser.Password == password)
            {
                Preferences.Set("UserUIN", uin);
                //await DisplayAlert("Успех", "Вход прошёл успешно!", "OK");
                await Navigation.PushAsync(new StartQ4());
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверный пароль.", "OK");
            }
        }
        else
        {
            var newUser = new User
            {
                UIN = uin,
                LastName = "ВашеФамилия", // Выберите значения для новой регистрации
                FirstName = "ВашеИмя",
                Patronymic = "ВашеОтчество",
                Email = "ВашEmail",
                IdCard = "ВашIdCard",
                Password = password
            };

            await userService.RegisterUser(newUser);
            Preferences.Set("UserUIN", uin);
            //await DisplayAlert("Успех", "Регистрация завершена успешно!", "OK");
            await Navigation.PushAsync(new StartQ4());
        }
    }
}
