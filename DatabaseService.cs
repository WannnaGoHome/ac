using System;
using System.Threading.Tasks;
using Npgsql;
using Dapper;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Метод для проверки учетных данных студента
    public async Task<bool> ValidateStudentAsync(long uin, string password)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            // Запрос для проверки, является ли пользователь студентом и правильно ли введен пароль
            string query = @"
                SELECT COUNT(1)
                FROM users u
                INNER JOIN roles r ON u.role_id = r.role_id
                WHERE u.uin = @UIN AND u.password_hash = @Password AND r.role_name = 'student'";

            var parameters = new { UIN = uin, Password = password };
            return await connection.ExecuteScalarAsync<bool>(query, parameters);
        }
    }

    // Метод для проверки учетных данных преподавателя
    public async Task<bool> ValidateTeacherAsync(long uin, string password)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            // Запрос для проверки, является ли пользователь преподавателем и правильно ли введен пароль
            string query = @"
                SELECT COUNT(1)
                FROM users u
                INNER JOIN roles r ON u.role_id = r.role_id
                WHERE u.uin = @UIN AND u.password_hash = @Password AND r.role_name = 'teacher'";

            var parameters = new { UIN = uin, Password = password };
            return await connection.ExecuteScalarAsync<bool>(query, parameters);
        }
    }
}
