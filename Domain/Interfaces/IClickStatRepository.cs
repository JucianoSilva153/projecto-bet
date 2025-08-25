using Domain.Entities;

namespace Domain.Interfaces;

public interface IClickStatRepository : IRepository<ClickStat>
{
    Task<int> GetClicksByLinkIdAsync(int linkId);
    Task<Dictionary<DateTime, int>> GetClicksGroupedByDateAsync(int linkId);
}