namespace Domain.Entities;

public class Article : Entity
{
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime PublishedAt { get; set; } = DateTime.Now;
    public string Category { get; set; }
}
