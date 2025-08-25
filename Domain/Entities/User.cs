namespace Domain.Entities;

public class User : Entity
{
    public string Username { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    // public string Role { get; set; } = "Admin";
}
