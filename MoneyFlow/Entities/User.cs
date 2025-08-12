namespace MoneyFlow.Entities;

public class User
{
    public int UsrerId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public ICollection<Service> Services { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
