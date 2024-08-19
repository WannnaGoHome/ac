using System.Text.Json;

public class LessonService
{
    private readonly string _filePath;

    public LessonService()
    {
        _filePath = Path.Combine(FileSystem.AppDataDirectory, "lessons.json");
    }

    public async Task<List<Lesson>> GetLessonsAsync()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Lesson>();
        }

        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<Lesson>>(json);
    }

    public async Task AddLessonAsync(Lesson lesson)
    {
        var lessons = await GetLessonsAsync();
        lessons.Add(lesson);

        var json = JsonSerializer.Serialize(lessons);
        await File.WriteAllTextAsync(_filePath, json);
    }
}
