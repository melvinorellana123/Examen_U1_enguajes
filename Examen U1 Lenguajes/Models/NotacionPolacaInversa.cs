using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Examen_U1_Lenguajes.Models;

public class NotacionPolacaInversa
{
    [Display(Name = "Notacion Polaca Inversa")]
    [Required(ErrorMessage = "El campo no puede estar vacio")]
    public string NotacionPolacaInversaValor { get; set; }
}