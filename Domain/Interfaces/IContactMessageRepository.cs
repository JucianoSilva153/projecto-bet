using Domain.Entities;

namespace Domain.Interfaces;

public interface IContactMessageRepository : IRepository<ContactMessage>
{
    Task<IEnumerable<ContactMessage>> GetRecentMessagesAsync(int count = 10);
    Task<IEnumerable<ContactMessage>> SearchByEmailOrNameAsync(string searchTerm);
}