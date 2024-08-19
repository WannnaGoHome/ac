using System;
using System.Linq;
using Microsoft.Maui.Controls;

namespace AC
{
    public partial class RoomInfo : ContentPage
    {
        private LessonService _lessonService;

        public RoomInfo()
        {
            InitializeComponent();
            _lessonService = new LessonService();
        }
        private async void GoBack(object sender, EventArgs e)
        {
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

        private async void OnLessonTapped(object sender, ItemTappedEventArgs e)
        {
            var lesson = e.Item as Lesson; // Предполагается, что у вас есть класс Lesson

            if (lesson != null)
            {
                string result = await DisplayPromptAsync("Введите PIN-код", "Введите четырехзначный PIN-код", "Подтвердить", "Отмена", keyboard: Keyboard.Numeric);

                if (result == "1234")
                {
                    await DisplayAlert("Успех", "Вы успешно отметились!", "OK");
                    await Navigation.PushAsync(new LessonInfo());
                }
                else
                {
                    await DisplayAlert("Ошибка", "PIN-код неверный", "OK");
                }
            }
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var lessons = await _lessonService.GetLessonsAsync();
            lessonsListView.ItemsSource = lessons.Where(lesson => lesson.Room == roomNameEntry.Text); // Фильтр по комнате
        }

        private async void OnNewLessonButtonClicked(object sender, EventArgs e)
        {
            // Переход на страницу для создания нового урока
            await Navigation.PushAsync(new NewLesson());
        }
    }
}
