using CalculadoraApi.Services;

namespace CalculadoraApi.Tests;

public class CalculadoraServiceTests
{
    private readonly CalculadoraService _calc = new();

    [Fact]
    public void Sumar_DosNumeros_DevuelveLaSuma()
    {
        Assert.Equal(5, _calc.Sumar(2, 3));
    }

    [Fact]
    public void Restar_DosNumeros_DevuelveLaResta()
    {
        Assert.Equal(-1, _calc.Restar(2, 3));
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(-2, 3, -6)]
    [InlineData(0, 99, 0)]
    public void Multiplicar_VariosCasos(int a, int b, int esperado)
    {
        Assert.Equal(esperado, _calc.Multiplicar(a, b));
    }

    [Fact]
    public void Dividir_DosNumeros_DevuelveDecimal()
    {
        Assert.Equal(2.5, _calc.Dividir(5, 2));
    }

    [Fact]
    public void Dividir_EntreCero_LanzaExcepcion()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(1, 0));
    }

    [Theory]
    [InlineData(4, true)]
    [InlineData(7, false)]
    [InlineData(0, true)]
    public void EsPar_VariosCasos(int numero, bool esperado)
    {
        Assert.Equal(esperado, _calc.EsPar(numero));
    }
}
