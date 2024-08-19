using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AC
{
    public class UserService
    {
        private readonly string _filePath = Path.Combine(FileSystem.AppDataDirectory, "users.json");

        public async Task RegisterUser(User user)
        {
            var users = await LoadUsersAsync();

            // Проверяем, существует ли уже пользователь с таким UIN
            if (users.Any(u => u.UIN == user.UIN))
            {
                throw new Exception("User already exists.");
            }

            // Добавляем нового пользователя в список
            users.Add(user);
            await SaveUsersAsync(users);
        }

        public UserService()
        {
            // Ensure the file exists
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public async Task<User> GetUserByUINAsync(string uin)
        {
            var users = await LoadUsersAsync();
            return users.FirstOrDefault(u => u.UIN == uin);
        }

        public async Task UpdateUserAsync(User user)
        {
            var users = await LoadUsersAsync();
            var existingUser = users.FirstOrDefault(u => u.UIN == user.UIN);

            if (existingUser != null)
            {
                existingUser.LastName = user.LastName;
                existingUser.FirstName = user.FirstName;
                existingUser.Patronymic = user.Patronymic;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                // Update other fields as needed
                await SaveUsersAsync(users);
            }
        }

        public async Task SaveUserAsync(User user)
        {
            var users = await LoadUsersAsync();
            users.Add(user);
            await SaveUsersAsync(users);
        }

        private async Task<List<User>> LoadUsersAsync()
        {
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        private async Task SaveUsersAsync(List<User> users)
        {
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
