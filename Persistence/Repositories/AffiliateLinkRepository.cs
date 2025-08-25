using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class AffiliateLinkRepository : IAffiliateLinkRepository
{
    private readonly AppDbContext _context;

    public AffiliateLinkRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AffiliateLink?> GetByIdAsync(int id)
    {
        return await _context.AffiliateLinks.FindAsync(id);
    }

    public async Task<IEnumerable<AffiliateLink>> GetAllAsync()
    {
        return await _context.AffiliateLinks.ToListAsync();
    }

    public async Task<AffiliateLink> AddAsync(AffiliateLink entity)
    {
        _context.AffiliateLinks.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<AffiliateLink> UpdateAsync(AffiliateLink entity)
    {
        _context.AffiliateLinks.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.AffiliateLinks.FindAsync(id);
        if (entity == null) return false;

        _context.AffiliateLinks.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<AffiliateLink>> GetHighlightedAsync()
    {
        return await _context.AffiliateLinks
            .Where(link => link.IsHighlighted)
            .ToListAsync();
    }

    public async Task<IEnumerable<AffiliateLink>> SearchByNameAsync(string keyword)
    {
        return await _context.AffiliateLinks
            .Where(link => link.Name.Contains(keyword))
            .ToListAsync();
    }

}