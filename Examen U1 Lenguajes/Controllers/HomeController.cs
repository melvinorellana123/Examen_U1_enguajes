using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Examen_U1_Lenguajes.Models;
using Examen_U1_Lenguajes.Models.Interfaces;
using Examen_U1_Lenguajes.Services;

namespace Examen_U1_Lenguajes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly INotacionPolacaInversa _repositorioNotacionPolacaInversa;

    public HomeController(ILogger<HomeController> logger, INotacionPolacaInversa repositorioNotacionPolacaInversa)
    {
        _logger = logger;
        _repositorioNotacionPolacaInversa = new RepositorioNotacionPolacaInversa();
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Obtener(NotacionPolacaInversa notacionPolacaInversa)
    {
        _repositorioNotacionPolacaInversa.ObtenerNotacionPolacaInversa();
        return RedirectToAction("Index");
    }
    
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}