using Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ClickStatService
{
    private readonly IClickStatRepository _repository;

    public ClickStatService(IClickStatRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClickStatDto?> GetByIdAsync(int id)
    {
        try
        {
            var stat = await _repository.GetByIdAsync(id);
            if (stat == null) return null;

            return new ClickStatDto(stat.Id, stat.AffiliateLinkId, stat.ClickedAt);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao buscar ClickStat por ID -> {e.Message}");
            return null;
        }
    }

    public async Task<List<ClickStatDto>> GetAllAsync()
    {
        try
        {
            var stats = await _repository.GetAllAsync();
            return stats.Select(s => new ClickStatDto(s.Id, s.AffiliateLinkId, s.ClickedAt)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao listar ClickStats -> {e.Message}");
            return [];
        }
    }

    public async Task<bool> RegisterClickAsync(int affiliateLinkId)
    {
        try
        {
            var click = new ClickStat
            {
                AffiliateLinkId = affiliateLinkId,
                ClickedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(click);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao registrar clique -> {e.Message}");
            return false;
        }
    }

    public async Task<int> GetClicksByLinkIdAsync(int linkId)
    {
        try
        {
            return await _repository.GetClicksByLinkIdAsync(linkId);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao contar cliques por link -> {e.Message}");
            return 0;
        }
    }

    public async Task<Dictionary<DateTime, int>> GetClicksGroupedByDateAsync(int linkId)
    {
        try
        {
            return await _repository.GetClicksGroupedByDateAsync(linkId);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao agrupar cliques por data -> {e.Message}");
            return new();
        }
    }
}
