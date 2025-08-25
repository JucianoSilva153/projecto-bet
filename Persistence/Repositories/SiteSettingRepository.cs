using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class SiteSettingRepository : ISiteSettingRepository
{
    private readonly AppDbContext _context;

    public SiteSettingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<SiteSetting?> GetByIdAsync(int id)
    {
        return await _context.SiteSettings.FindAsync(id);
    }

    public async Task<IEnumerable<SiteSetting>> GetAllAsync()
    {
        return await _context.SiteSettings.ToListAsync();
    }

    public async Task<SiteSetting> AddAsync(SiteSetting entity)
    {
        _context.SiteSettings.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<SiteSetting> UpdateAsync(SiteSetting entity)
    {
        _context.SiteSettings.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.SiteSettings.FindAsync(id);
        if (entity == null) return false;

        _context.SiteSettings.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<SiteSetting?> GetByKeyAsync(string key)
    {
        return await _context.SiteSettings.FirstOrDefaultAsync(s => s.Key == key);
    }

    public async Task<SiteSetting> SetOrUpdateAsync(string key, string value)
    {
        var setting = await _context.SiteSettings.FirstOrDefaultAsync(s => s.Key == key);
        if (setting != null)
        {
            setting.Value = value;
            _context.SiteSettings.Update(setting);
        }
        else
        {
            setting = new SiteSetting { Key = key, Value = value };
            _context.SiteSettings.Add(setting);
        }

        await _context.SaveChangesAsync();
        return setting;
    }

}