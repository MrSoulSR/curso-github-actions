using CalculadoraApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculadoraController(CalculadoraService calculadora) : ControllerBase
{
    [HttpGet("sumar")]
    public ActionResult<int> Sumar(int a, int b) => Ok(calculadora.Sumar(a, b));

    [HttpGet("restar")]
    public ActionResult<int> Restar(int a, int b) => Ok(calculadora.Restar(a, b));

    [HttpGet("multiplicar")]
    public ActionResult<int> Multiplicar(int a, int b) => Ok(calculadora.Multiplicar(a, b));

    [HttpGet("dividir")]
    public ActionResult<double> Dividir(int a, int b)
    {
        if (b == 0)
            return BadRequest("No se puede dividir entre cero.");

        return Ok(calculadora.Dividir(a, b));
    }

    [HttpGet("espar/{numero}")]
    public ActionResult<bool> EsPar(int numero) => Ok(calculadora.EsPar(numero));
}
