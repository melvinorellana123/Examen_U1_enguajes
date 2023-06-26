using System.Diagnostics;
using System.Text.RegularExpressions;
using Examen_U1_Lenguajes.Models;
using Examen_U1_Lenguajes.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Examen_U1_Lenguajes.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
    }

    public IActionResult Index()
    {
        return View(new NotacionPolacaInversaViewModel());
    }

    [HttpPost]
    public IActionResult Obtener(NotacionPolacaInversaViewModel notacionPolacaInversa)
    {
        if (!ModelState.IsValid)
            return View("Index", notacionPolacaInversa);

        bool sintaxisCorrecta = ValidarOperandosYFunciones(notacionPolacaInversa.NotacionPolacaInversaValor);

        if (!sintaxisCorrecta)
        {
            ModelState.AddModelError("NotacionPolacaInversaValor",
                "La sintaxis no es válida, solo se permiten números y operadores aritméticos. (Vefifique si no tiene espacio demas)");
            return View("Index", notacionPolacaInversa);
        }

        try
        {
            double respuesta =
                EvaluarNotacionPolacaInversa.EvaluarRPN(notacionPolacaInversa.NotacionPolacaInversaValor);
            notacionPolacaInversa.Resultado = respuesta.ToString("N");
            return View("Index", notacionPolacaInversa);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("NotacionPolacaInversaValor", e.Message);
            return View("Index", notacionPolacaInversa);
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private bool ValidarOperandosYFunciones(string valor)
    {
        Regex regex = new Regex(@"^(\d+|[+\-*/])+(\s(\d+|[+\-*/])+)*$");
        return regex.IsMatch(valor);
    }
}