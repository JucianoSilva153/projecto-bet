namespace Common;

public record UserDto(int Id, string Username /*, string Role*/);
public record CreateUserDto(string Username, string Password);

public record AffiliateLinkDto(int Id, string Name, string Description, string AffiliateUrl, string BonusInfo, string ImageUrl, bool IsHighlighted);
public class AffiliateLinkFormModel
{
    public int? Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string BonusInfo { get; set; } = "";
    public string AffiliateUrl { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public bool IsHighlighted { get; set; } = true;
    public bool IsEditing { get; set; }
}
public record CreateAffiliateLinkDto(string Name, string Description, string AffiliateUrl, string BonusInfo, string ImageUrl, bool IsHighlighted);

public record ArticleDto(int Id, string Title, string Content, DateTime PublishedAt, string Category);
public record CreateArticleDto(string Title, string Content, string Category);

public record ContactMessageDto(int Id, string Name, string Email, string Message);
public record CreateContactMessageDto(string Name, string Email, string Message);

public record ClickStatDto(int Id, int AffiliateLinkId, DateTime ClickedAt);

public record SiteSettingDto(int Id, string Key, string Value);
public record CreateSiteSettingDto(string Key, string Value);