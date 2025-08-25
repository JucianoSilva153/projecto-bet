using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class ClickStatRepository : IClickStatRepository
{
    private readonly AppDbContext _context;

    public ClickStatRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ClickStat?> GetByIdAsync(int id)
    {
        return await _context.ClickStats
            .Include(c => c.AffiliateLink)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<ClickStat>> GetAllAsync()
    {
        return await _context.ClickStats
            .Include(c => c.AffiliateLink)
            .ToListAsync();
    }

    public async Task<ClickStat> AddAsync(ClickStat entity)
    {
        _context.ClickStats.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ClickStat> UpdateAsync(ClickStat entity)
    {
        _context.ClickStats.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.ClickStats.FindAsync(id);
        if (entity == null) return false;

        _context.ClickStats.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<int> GetClicksByLinkIdAsync(int linkId)
    {
        return await _context.ClickStats.CountAsync(c => c.AffiliateLinkId == linkId);
    }

    public async Task<Dictionary<DateTime, int>> GetClicksGroupedByDateAsync(int linkId)
    {
        return await _context.ClickStats
            .Where(c => c.AffiliateLinkId == linkId)
            .GroupBy(c => c.ClickedAt.Date)
            .ToDictionaryAsync(g => g.Key, g => g.Count());
    }
}