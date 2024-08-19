namespace AC
{
    public partial class LessonInfo : ContentPage
    {
        private List<Student> students;

        public LessonInfo()
        {
            InitializeComponent();
            LoadStudentData(); // Загрузка данных при инициализации
        }

        private async void OnStatisticsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Statistics());
        }

        private async void GoBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void OnSaveBtn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RoomInfo());
        }

        private async void OnDesktopClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Desktop());
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }

        private void LoadStudentData()
        {
            // Инициализируем список студентов
            students = new List<Student>
            {
                new Student { Name = "Иванов Иван", ScanTime = "8:07", Status = "orange" },
                new Student { Name = "Петрова Анна", ScanTime = "7:55", Status = "green" },
                new Student { Name = "Сидоров Алексей", ScanTime = "7:53", Status = "green" }
            };

            UpdateStudentList();
        }

        private void UpdateStudentList()
        {
            // Очистить существующий список
            StudentsStackLayout.Children.Clear();

            foreach (var student in students)
            {
                // Генерация элементов для каждого студента
                StudentsStackLayout.Children.Add(CreateStudentFrame(student));
            }
        }

        private Frame CreateStudentFrame(Student student)
        {
            var nameLabel = new Label
            {
                Text = student.Name,
                TextColor = GetColorFromStatus(student.Status),
                FontSize = 16,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(10, 0, 0, 0) // Increased left padding
            };

            var scanTimeLabel = new Label
            {
                Text = student.ScanTime,
                FontSize = 13,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.FromArgb("#23034a")
            };

            var commentButton = new ImageButton
            {
                Source = "comment.png",
                WidthRequest = 30,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                Margin = 5, // Added padding
                Command = new Command(() => ShowCommentDialog(student))
            };

            // Change color on name tap
            nameLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (nameLabel.TextColor== Colors.Green)
                    nameLabel.TextColor = Colors.Orange; // Change color on tap
                    else if (nameLabel.TextColor == Colors.Orange)
                        nameLabel.TextColor = Colors.Red;
                    else if (nameLabel.TextColor == Colors.Red)
                        nameLabel.TextColor = Colors.Green;
                })
            });

            var grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
            };

            // Добавляем элементы в Grid
            grid.Children.Add(nameLabel);
            Grid.SetColumn(nameLabel, 0);

            grid.Children.Add(commentButton);
            Grid.SetColumn(commentButton, 1);

            grid.Children.Add(scanTimeLabel);
            Grid.SetColumn(scanTimeLabel, 2);

            return new Frame
            {
                BackgroundColor = Color.FromArgb("#f3edfa"),
                CornerRadius = 10,
                Padding = 10,
                Content = grid
            };
        }

        private void ShowCommentDialog(Student student)
        {
            var commentEntry = new Entry
            {
                Placeholder = "Введите комментарий",
                WidthRequest = 200,
                HorizontalTextAlignment = TextAlignment.Center,
                PlaceholderColor = Color.FromArgb("#beafcb")
            }; 

            var confirmButton = new Button
            {
                WidthRequest = 250,
                BackgroundColor = Color.FromArgb("#beafcb"),
                TextColor = Color.FromArgb("#23034a"),
                FontSize = 18,
                HeightRequest = 35,
                Text = "ОК"
            };

            // Создаем Layout для ввода комментария и кнопки ОК
            var commentLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { commentEntry, confirmButton }
            };

            // Показать диалоговое окно для ввода комментария
            StudentsStackLayout.Children.Add(commentLayout);

            confirmButton.Clicked += (s, e) =>
            {
                student.Comment = commentEntry.Text;
                DisplayAlert("Комментарий", $"Комментарий сохранен для {student.Name}", "OK");

                // Скрыть строку ввода и кнопку ОК
                commentEntry.IsVisible = false;
                confirmButton.IsVisible = false;
            };
        }

        private Color GetColorFromStatus(string status)
        {
            return status switch
            {
                "green" => Colors.Green,
                "yellow" => Colors.Yellow,
                "red" => Colors.Red,
                _ => Colors.Green
            };
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string ScanTime { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
    }
}
