using Microsoft.EntityFrameworkCore;
using MoneyFlow.Context;
using MoneyFlow.Entities;

namespace MoneyFlow.Managers;

public class ServiceManager(AppDbContext _dbContext)
{
    public IEnumerable<Service> GetAll(int userId) => _dbContext.Services.Where(user => user.UserId.Equals(userId)).ToList();
}
