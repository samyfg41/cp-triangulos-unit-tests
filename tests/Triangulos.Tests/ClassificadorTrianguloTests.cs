using Triangulos.Core;
using Xunit;

namespace Triangulos.Tests;

public class ClassificadorTrianguloTests
{
    [Theory]
    [InlineData(1.0, 2.0, 3.0)]
    [InlineData(3.0, 1.0, 2.0)]
    [InlineData(2.0, 3.0, 1.0)]
    public void Classificar_SomaDeDoisLadosIgualAoTerceiro_RetornaNaoEhTriangulo(
        double a, double b, double c)
    {
        // Arrange
        var esperado = TipoTriangulo.NaoEhTriangulo;
        
        // Act
        var resultado = ClassificadorTriangulo.Classificar(a, b, c);
        
        // Assert
        Assert.Equal(esperado, resultado);
    }
    
    [Theory]
    [InlineData(2.0, 2.0, 3.0)]
    [InlineData(2.0, 3.0, 2.0)]
    [InlineData(3.0, 2.0, 2.0)]
    public void Classificar_DoisLadosIguais_RetornaIsosceles(
        double a, double b, double c)
    {
        // Arrange
        var esperado = TipoTriangulo.Isosceles;
    
        // Act
        var resultado = ClassificadorTriangulo.Classificar(a, b, c);
    
        // Assert
        Assert.Equal(esperado, resultado);
    }
    
    [Theory]
    [InlineData(3.0, 4.0, 5.0, true)]
    [InlineData(2.0, 2.0, 2.0, true)]
    [InlineData(2.0, 3.0, 4.0, true)]
    [InlineData(1.0, 2.0, 3.0, false)]
    [InlineData(3.0, 1.0, 2.0, false)]
    [InlineData(2.0, 3.0, 1.0, false)]
    [InlineData(1.0, 2.0, 4.0, false)]
    [InlineData(0.0, 2.0, 2.0, false)]
    [InlineData(-1.0, 2.0, 2.0, false)]
    public void EhTriangulo_EntradasVariadas_RetornaResultadoEsperado(
        double a, double b, double c, bool esperado)
    {
        // Arrange
        // Dados recebidos pelo Theory
    
        // Act
        var resultado = ClassificadorTriangulo.EhTriangulo(a, b, c);
    
        // Assert
        Assert.Equal(esperado, resultado);
    }
}