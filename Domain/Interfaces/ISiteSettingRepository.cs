using Domain.Entities;

namespace Domain.Interfaces;

public interface ISiteSettingRepository : IRepository<SiteSetting>
{
    Task<SiteSetting?> GetByKeyAsync(string key);
    Task<SiteSetting> SetOrUpdateAsync(string key, string value);
}