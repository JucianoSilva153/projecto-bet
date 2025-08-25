using Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        try
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto(user.Id, user.Username);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao buscar usuário -> {e.Message}");
            return null;
        }
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        try
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserDto(u.Id, u.Username)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao listar usuários -> {e.Message}");
            return [];
        }
    }

    public async Task<bool> CreateAsync(CreateUserDto dto)
    {
        try
        {
            var exists = await _repository.ExistsByUsernameAsync(dto.Username);
            if (exists) return false;

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = dto.Password
            };

            await _repository.AddAsync(user);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao criar usuário -> {e.Message}");
            return false;
        }
    }

    public async Task<UserDto?> LoginAsync(string username, string password)
    {
        try
        {
            var user = await _repository.GetByUsernameAsync(username);
            if (user == null || (password != user.PasswordHash))
                return null;

            return new UserDto(user.Id, user.Username);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao autenticar usuário -> {e.Message}");
            return null;
        }
    }
}