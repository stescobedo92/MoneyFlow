using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Managers;

namespace MoneyFlow.Controllers;

public class ServiceController(ServiceManager _serviceManager) : Controller
{
    public IActionResult Index()
    {
        return View(_serviceManager.GetAll(1));
    }
}
