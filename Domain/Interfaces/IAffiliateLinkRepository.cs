using Domain.Entities;

namespace Domain.Interfaces;

public interface IAffiliateLinkRepository : IRepository<AffiliateLink>
{
    Task<IEnumerable<AffiliateLink>> GetHighlightedAsync();
    Task<IEnumerable<AffiliateLink>> SearchByNameAsync(string keyword);
}