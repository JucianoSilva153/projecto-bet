namespace Domain.Entities;

public class ClickStat : Entity
{
    public int AffiliateLinkId { get; set; }
    public DateTime ClickedAt { get; set; } = DateTime.Now;

    public AffiliateLink AffiliateLink { get; set; }
}
