using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class ContactMessageRepository : IContactMessageRepository
{
    private readonly AppDbContext _context;

    public ContactMessageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ContactMessage?> GetByIdAsync(int id)
    {
        return await _context.ContactMessages.FindAsync(id);
    }

    public async Task<IEnumerable<ContactMessage>> GetAllAsync()
    {
        return await _context.ContactMessages.ToListAsync();
    }

    public async Task<ContactMessage> AddAsync(ContactMessage entity)
    {
        _context.ContactMessages.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ContactMessage> UpdateAsync(ContactMessage entity)
    {
        _context.ContactMessages.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.ContactMessages.FindAsync(id);
        if (entity == null) return false;

        _context.ContactMessages.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ContactMessage>> GetRecentMessagesAsync(int count = 10)
    {
        return await _context.ContactMessages
            .OrderByDescending(c => c.CreatedAt)
            .Take(count)
            .ToListAsync();
    }

    public async Task<IEnumerable<ContactMessage>> SearchByEmailOrNameAsync(string searchTerm)
    {
        return await _context.ContactMessages
            .Where(c => c.Name.Contains(searchTerm) || c.Email.Contains(searchTerm))
            .ToListAsync();
    }

}