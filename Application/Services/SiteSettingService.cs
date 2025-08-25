using Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class SiteSettingService
{
    private readonly ISiteSettingRepository _repository;

    public SiteSettingService(ISiteSettingRepository repository)
    {
        _repository = repository;
    }

    public async Task<SiteSettingDto?> GetByIdAsync(int id)
    {
        try
        {
            var setting = await _repository.GetByIdAsync(id);
            if (setting == null) return null;

            return new SiteSettingDto(setting.Id, setting.Key, setting.Value);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao obter configuração por ID -> {e.Message}");
            return null;
        }
    }

    public async Task<List<SiteSettingDto>> GetAllAsync()
    {
        try
        {
            var settings = await _repository.GetAllAsync();
            return settings.Select(s => new SiteSettingDto(s.Id, s.Key, s.Value)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao listar configurações -> {e.Message}");
            return [];
        }
    }

    public async Task<bool> CreateAsync(CreateSiteSettingDto dto)
    {
        try
        {
            var setting = new SiteSetting
            {
                Key = dto.Key,
                Value = dto.Value
            };

            await _repository.AddAsync(setting);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao criar configuração -> {e.Message}");
            return false;
        }
    }

    public async Task<SiteSettingDto?> GetByKeyAsync(string key)
    {
        try
        {
            var setting = await _repository.GetByKeyAsync(key);
            if (setting == null) return null;

            return new SiteSettingDto(setting.Id, setting.Key, setting.Value);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao obter configuração por chave -> {e.Message}");
            return null;
        }
    }

    public async Task<SiteSettingDto?> SetOrUpdateAsync(string key, string value)
    {
        try
        {
            var setting = await _repository.SetOrUpdateAsync(key, value);
            return new SiteSettingDto(setting.Id, setting.Key, setting.Value);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao definir ou atualizar configuração -> {e.Message}");
            return null;
        }
    }
}
