using Microsoft.EntityFrameworkCore;
using MoneyFlow.Context;
using MoneyFlow.Entities;
using MoneyFlow.Models;

namespace MoneyFlow.Managers;

public class ServiceManager(AppDbContext _dbContext)
{
    public IEnumerable<ServiceViewModel> GetAll(int userId) => _dbContext.Services.Where(user => user.UserId.Equals(userId)).
                                                     Select(serviceVM => new ServiceViewModel
                                                     {
                                                        ServiceId = serviceVM.ServiceId,
                                                        UserId = serviceVM.UserId,
                                                        Name = serviceVM.Name,
                                                        Type = serviceVM.Type
                                                     })
                                                     .ToList();
}
