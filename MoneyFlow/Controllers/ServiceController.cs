using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Managers;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers;

public class ServiceController(ServiceManager _serviceManager) : Controller
{
    [HttpGet]
    public IActionResult Index() => View(_serviceManager.GetAll(1));

    [HttpGet]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult New(ServiceViewModel serviceViewModel)
    {
        if(!ModelState.IsValid) return View(serviceViewModel);

        serviceViewModel.UserId = 1; // Hardcoded for demo purposes
        var rowsAffected = _serviceManager.NewService(serviceViewModel);
        if (rowsAffected == 1) return RedirectToAction("Index");

        ViewBag.message = "Error";

        return View();
    }
}
