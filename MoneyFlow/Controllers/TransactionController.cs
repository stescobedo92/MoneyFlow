using Microsoft.AspNetCore.Mvc;
using MoneyFlow.DTOs;
using MoneyFlow.Managers;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers;

public class TransactionController(ServiceManager _serviceManager, TransactionManager _transactionManager) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SericeByTypes(string typeService) => Ok(_serviceManager.GetByType(1, typeService));

    [HttpPost]
    public IActionResult New([FromBody] TransactionDTO transactionDto)
    {
        transactionDto.UserId = 1; // Assuming a hardcoded user ID for demonstration purposes
        return Ok(_transactionManager.NewTransaction(transactionDto));
    }
}
