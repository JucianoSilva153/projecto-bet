namespace Domain.Entities;

public class AffiliateLink : Entity
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string AffiliateUrl { get; set; } = "";
    public string BonusInfo { get; set; } = "";
    public string? ImageUrl { get; set; }
    public bool IsHighlighted { get; set; }
}
