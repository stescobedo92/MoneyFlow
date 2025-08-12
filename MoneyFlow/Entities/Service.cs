namespace MoneyFlow.Entities;

public class Service
{
    public int ServiceId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;

    public User User { get; set; }
}
