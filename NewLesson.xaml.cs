using Microsoft.Maui.Controls;

namespace AC
{
    public partial class NewLesson : ContentPage
    {
        private LessonService _lessonService;

        public NewLesson()
        {
            InitializeComponent();
            _lessonService = new LessonService();
        }

        private async void GoBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var newLesson = new Lesson
            {
                LessonId = Guid.NewGuid().ToString(),
                Teacher = teacherEntry.Text,
                StartTime = DateTime.Today.Add(startTimePicker.Time),
                EndTime = DateTime.Today.Add(endTimePicker.Time),
                Room = roomEntry.Text,
                Group = groupEntry.Text,
                Description = descriptionEntry.Text
            };

            await _lessonService.AddLessonAsync(newLesson);

            // Обновите окно аудитории или выполните другие действия после добавления урока
            await Navigation.PopAsync();
        }
    }
}
