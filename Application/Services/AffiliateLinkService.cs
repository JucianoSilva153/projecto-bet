using Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class AffiliateLinkService
{
    private readonly IAffiliateLinkRepository _repository;

    public AffiliateLinkService(IAffiliateLinkRepository repository)
    {
        _repository = repository;
    }

    public async Task<AffiliateLinkDto?> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new AffiliateLinkDto(entity.Id, entity.Name, entity.Description, entity.AffiliateUrl, entity.BonusInfo, entity.ImageUrl, entity.IsHighlighted);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao buscar AffiliateLink por ID: {e.Message}");
            return null;
        }
    }

    public async Task<List<AffiliateLinkDto>> GetAllAsync()
    {
        try
        {
            var list = await _repository.GetAllAsync();
            return list.Select(x => new AffiliateLinkDto(x.Id, x.Name, x.Description, x.AffiliateUrl, x.BonusInfo, x.ImageUrl, x.IsHighlighted)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao listar AffiliateLinks: {e.Message}");
            return [];
        }
    }

    public async Task<bool> CreateAsync(CreateAffiliateLinkDto dto)
    {
        try
        {
            var entity = new AffiliateLink
            {
                Name = dto.Name,
                Description = dto.Description,
                AffiliateUrl = dto.AffiliateUrl,
                BonusInfo = dto.BonusInfo,
                ImageUrl = dto.ImageUrl,
                IsHighlighted = dto.IsHighlighted
            };

            await _repository.AddAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao criar AffiliateLink: {e.Message}");
            return false;
        }
    }

    public async Task<bool> UpdateAsync(AffiliateLinkDto dto)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return false;

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.AffiliateUrl = dto.AffiliateUrl;
            entity.BonusInfo = dto.BonusInfo;
            entity.ImageUrl = dto.ImageUrl;
            entity.IsHighlighted = dto.IsHighlighted;

            await _repository.UpdateAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao atualizar AffiliateLink: {e.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            return await _repository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao deletar AffiliateLink: {e.Message}");
            return false;
        }
    }

    public async Task<List<AffiliateLinkDto>> GetHighlightedAsync()
    {
        try
        {
            var list = await _repository.GetHighlightedAsync();
            return list.Select(x => new AffiliateLinkDto(x.Id, x.Name, x.Description, x.AffiliateUrl, x.BonusInfo, x.ImageUrl, x.IsHighlighted)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao buscar destaques: {e.Message}");
            return [];
        }
    }

    public async Task<List<AffiliateLinkDto>> SearchByNameAsync(string keyword)
    {
        try
        {
            var list = await _repository.SearchByNameAsync(keyword);
            return list.Select(x => new AffiliateLinkDto(x.Id, x.Name, x.Description, x.AffiliateUrl, x.BonusInfo, x.ImageUrl, x.IsHighlighted)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao buscar por nome: {e.Message}");
            return [];
        }
    }
}
