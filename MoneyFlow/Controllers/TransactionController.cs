using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Managers;

namespace MoneyFlow.Controllers;

public class TransactionController(ServiceManager _serviceManager, TransactionManager _transactionManager) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
