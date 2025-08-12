using System.ComponentModel.DataAnnotations;

namespace MoneyFlow.Models;

public class ServiceViewModel
{
    public int ServiceId { get; set; }
    public int UserId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Type { get; set; } = string.Empty;
}
