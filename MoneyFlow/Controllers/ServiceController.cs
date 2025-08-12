using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Managers;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers;

public class ServiceController(ServiceManager _serviceManager) : Controller
{
    [HttpGet]
    public IActionResult Index() => View(_serviceManager.GetAll(1));

    [HttpGet]
    public IActionResult New() => View();

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

    [HttpGet]
    public IActionResult Edit(int id) => View(_serviceManager.GetServiceById(id));

    [HttpPost]
    public IActionResult Edit(ServiceViewModel serviceViewModel)
    {
        if (!ModelState.IsValid) return View(serviceViewModel);

        var response = _serviceManager.EditService(serviceViewModel);
        if(response == 1) return RedirectToAction("Index");

        ViewBag.message = "Error";
        return View(serviceViewModel);
    }
}
