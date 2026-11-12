using CalculadoraApi.Controllers;
using CalculadoraApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraApi.Tests;

public class CalculadoraControllerTests
{
    private readonly CalculadoraController _controller = new(new CalculadoraService());

    [Fact]
    public void Sumar_DevuelveOkConLaSuma()
    {
        var resultado = _controller.Sumar(2, 3);

        var ok = Assert.IsType<OkObjectResult>(resultado.Result);
        Assert.Equal(5, ok.Value);
    }

    [Fact]
    public void Dividir_DevuelveOkConElResultado()
    {
        var resultado = _controller.Dividir(5, 2);

        var ok = Assert.IsType<OkObjectResult>(resultado.Result);
        Assert.Equal(2.5, ok.Value);
    }

    [Fact]
    public void Dividir_EntreCero_DevuelveBadRequest()
    {
        var resultado = _controller.Dividir(1, 0);

        Assert.IsType<BadRequestObjectResult>(resultado.Result);
    }

    [Fact]
    public void EsPar_DevuelveOkConTrueParaNumeroPar()
    {
        var resultado = _controller.EsPar(8);

        var ok = Assert.IsType<OkObjectResult>(resultado.Result);
        Assert.Equal(true, ok.Value);
    }
}
