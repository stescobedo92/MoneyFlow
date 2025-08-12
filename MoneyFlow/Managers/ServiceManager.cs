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

    public int NewService(ServiceViewModel serviceVM)
    {
        var service = new Service
        {
            UserId = serviceVM.UserId,
            Name = serviceVM.Name,
            Type = serviceVM.Type
        };
        _dbContext.Services.Add(service);
        var rowsAffected = _dbContext.SaveChanges();

        return rowsAffected;
    }

    public ServiceViewModel GetServiceById(int serviceId)
    {
        var service = _dbContext.Services.FirstOrDefault(s => s.ServiceId.Equals(serviceId));
        if (service == null)
        {
            throw new InvalidOperationException($"Service with ID {serviceId} not found.");
        }

        var serviceModel = new ServiceViewModel
        {
            ServiceId = service.ServiceId,
            UserId = service.UserId,
            Name = service.Name,
            Type = service.Type
        };

        return serviceModel;
    }

    public int EditService(ServiceViewModel serviceViewModel)
    {
        var service = _dbContext.Services.FirstOrDefault(s => s.ServiceId.Equals(serviceViewModel.ServiceId));
        
        if (service == null)
        {
            throw new InvalidOperationException($"Service with ID {serviceViewModel.ServiceId} not found.");
        }

        service.Name = serviceViewModel.Name;
        service.Type = serviceViewModel.Type;

        _dbContext.Services.Update(service);
        var affectedRows = _dbContext.SaveChanges();

        return affectedRows;
    }
}
