using Triangulos.Core;
using Xunit;

namespace Triangulos.Tests;

public class CalculadoraTrianguloTests
{
    [Theory]
    [InlineData(3.0, 4.0, 5.0, 12.0)]
    [InlineData(2.0, 2.0, 2.0, 6.0)]
    [InlineData(2.0, 3.0, 4.0, 9.0)]
    [InlineData(2.5, 3.5, 4.0, 10.0)]
    public void Perimetro_TrianguloValido_RetornaSomaDosLados(
        double a, double b, double c, double esperado)
    {
        // Arrange
        // Dados recebidos pelo Theory

        // Act
        var resultado = CalculadoraTriangulo.Perimetro(a, b, c);

        // Assert
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(1.0, 2.0, 3.0)]
    [InlineData(1.0, 2.0, 4.0)]
    [InlineData(0.0, 2.0, 2.0)]
    [InlineData(-1.0, 2.0, 2.0)]
    public void Perimetro_TrianguloInvalido_LancaTrianguloInvalidoException(
        double a, double b, double c)
    {
        // Arrange
        // Dados recebidos pelo Theory

        // Act + Assert
        Assert.Throws<TrianguloInvalidoException>(
            () => CalculadoraTriangulo.Perimetro(a, b, c));
    }
    
    [Theory]
    [InlineData(3.0, 4.0, 5.0, 6.0)]
    [InlineData(2.0, 2.0, 2.0, 1.73)]
    [InlineData(2.0, 3.0, 4.0, 2.90)]
    [InlineData(5.0, 5.0, 6.0, 12.0)]
    public void Area_TrianguloValido_RetornaAreaPelaFormulaDeHeron(
        double a, double b, double c, double esperado)
    {
        // Arrange
        // Dados recebidos pelo Theory
    
        // Act
        var resultado = CalculadoraTriangulo.Area(a, b, c);
    
        // Assert
        Assert.Equal(esperado, resultado);
    }
    
    [Theory]
    [InlineData(1.0, 2.0, 3.0)]
    [InlineData(1.0, 2.0, 4.0)]
    [InlineData(0.0, 2.0, 2.0)]
    [InlineData(-1.0, 2.0, 2.0)]
    public void Area_TrianguloInvalido_LancaTrianguloInvalidoException(
        double a, double b, double c)
    {
        // Arrange
        // Dados recebidos pelo Theory
    
        // Act + Assert
        Assert.Throws<TrianguloInvalidoException>(
            () => CalculadoraTriangulo.Area(a, b, c));
    }
    
    [Theory]
    [InlineData(3.0, 4.0, 5.0, 36.87, 53.13, 90.0)]
    [InlineData(5.0, 3.0, 4.0, 90.0, 36.87, 53.13)]
    [InlineData(4.0, 5.0, 3.0, 53.13, 90.0, 36.87)]
    [InlineData(2.0, 2.0, 2.0, 60.0, 60.0, 60.0)]
    public void Angulos_TrianguloValido_RetornaAngulosCorretos(
        double a, double b, double c,
        double esperadoA, double esperadoB, double esperadoC)
    {
        // Arrange
        // Dados recebidos pelo Theory
    
        // Act
        var resultado = CalculadoraTriangulo.Angulos(a, b, c);
    
        // Assert
        Assert.Equal(esperadoA, resultado.A);
        Assert.Equal(esperadoB, resultado.B);
        Assert.Equal(esperadoC, resultado.C);
    }
    
    [Theory]
    [InlineData(1.0, 2.0, 3.0)]
    [InlineData(1.0, 2.0, 4.0)]
    [InlineData(0.0, 2.0, 2.0)]
    public void Angulos_TrianguloInvalido_LancaTrianguloInvalidoException(
        double a, double b, double c)
    {
        // Arrange
        // Dados recebidos pelo Theory

        // Act + Assert
        Assert.Throws<TrianguloInvalidoException>(
            () => CalculadoraTriangulo.Angulos(a, b, c));
    }
    
    [Theory]
    [InlineData(3.0, 4.0, 5.0, true)]
    [InlineData(5.0, 3.0, 4.0, true)]
    [InlineData(4.0, 5.0, 3.0, true)]
    [InlineData(2.0, 3.0, 4.0, false)]
    [InlineData(2.0, 2.0, 2.0, false)]
    public void EhRetangulo_TriangulosValidos_RetornaResultadoEsperado(
        double a, double b, double c, bool esperado)
    {
        // Arrange
        // Dados recebidos pelo Theory
    
        // Act
        var resultado = CalculadoraTriangulo.EhRetangulo(a, b, c);
    
        // Assert
        Assert.Equal(esperado, resultado);
    }
    
    [Theory]
    [InlineData(1.0, 2.0, 3.0)]
    [InlineData(1.0, 2.0, 4.0)]
    [InlineData(0.0, 2.0, 2.0)]
    public void EhRetangulo_TrianguloInvalido_LancaTrianguloInvalidoException(
        double a, double b, double c)
    {
        // Arrange
        // Dados recebidos pelo Theory

        // Act + Assert
        Assert.Throws<TrianguloInvalidoException>(
            () => CalculadoraTriangulo.EhRetangulo(a, b, c));
    }
    
    [Theory]
    [InlineData(3.0, 4.0, 5.0, TipoPorAngulo.Retangulo)]
    [InlineData(5.0, 3.0, 4.0, TipoPorAngulo.Retangulo)]
    [InlineData(4.0, 5.0, 3.0, TipoPorAngulo.Retangulo)]
    [InlineData(2.0, 3.0, 4.0, TipoPorAngulo.Obtusangulo)]
    [InlineData(2.0, 2.0, 2.0, TipoPorAngulo.Acutangulo)]
    public void ClassificarPorAngulo_TrianguloValido_RetornaTipoEsperado(
        double a, double b, double c, TipoPorAngulo esperado)
    {
        // Arrange
        // Dados recebidos pelo Theory
    
        // Act
        var resultado = CalculadoraTriangulo.ClassificarPorAngulo(a, b, c);
    
        // Assert
        Assert.Equal(esperado, resultado);
    }
    
    [Theory]
    [InlineData(1.0, 2.0, 3.0)]
    [InlineData(1.0, 2.0, 4.0)]
    [InlineData(0.0, 2.0, 2.0)]
    public void ClassificarPorAngulo_TrianguloInvalido_LancaTrianguloInvalidoException(
        double a, double b, double c)
    {
        // Arrange
        // Dados recebidos pelo Theory
    
        // Act + Assert
        Assert.Throws<TrianguloInvalidoException>(
            () => CalculadoraTriangulo.ClassificarPorAngulo(a, b, c));
    }
}