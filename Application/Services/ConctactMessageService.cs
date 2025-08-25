using Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ContactMessageService
{
    private readonly IContactMessageRepository _repository;

    public ContactMessageService(IContactMessageRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactMessageDto?> GetByIdAsync(int id)
    {
        try
        {
            var msg = await _repository.GetByIdAsync(id);
            if (msg == null) return null;

            return new ContactMessageDto(msg.Id, msg.Name, msg.Email, msg.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao buscar mensagem de contato -> {e.Message}");
            return null;
        }
    }

    public async Task<List<ContactMessageDto>> GetAllAsync()
    {
        try
        {
            var msgs = await _repository.GetAllAsync();
            return msgs.Select(m => new ContactMessageDto(m.Id, m.Name, m.Email, m.Message)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao listar mensagens -> {e.Message}");
            return [];
        }
    }

    public async Task<bool> CreateAsync(CreateContactMessageDto dto)
    {
        try
        {
            var msg = new ContactMessage
            {
                Name = dto.Name,
                Email = dto.Email,
                Message = dto.Message
            };

            await _repository.AddAsync(msg);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao criar mensagem de contato -> {e.Message}");
            return false;
        }
    }

    public async Task<List<ContactMessageDto>> GetRecentMessagesAsync(int count = 10)
    {
        try
        {
            var msgs = await _repository.GetRecentMessagesAsync(count);
            return msgs.Select(m => new ContactMessageDto(m.Id, m.Name, m.Email, m.Message)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao listar mensagens recentes -> {e.Message}");
            return [];
        }
    }

    public async Task<List<ContactMessageDto>> SearchByEmailOrNameAsync(string term)
    {
        try
        {
            var msgs = await _repository.SearchByEmailOrNameAsync(term);
            return msgs.Select(m => new ContactMessageDto(m.Id, m.Name, m.Email, m.Message)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao buscar mensagens por nome/email -> {e.Message}");
            return [];
        }
    }
}
