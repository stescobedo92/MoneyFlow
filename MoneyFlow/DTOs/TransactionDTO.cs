using MoneyFlow.Entities;

namespace MoneyFlow.DTOs;

public class TransactionDTO
{
    public int ServiceId { get; set; }
    public int UserId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public decimal TotalAmount { get; set; }
}
