using Triangulos.Core;
using Xunit;

namespace Triangulos.Tests;

public class AnalisadorTrianguloTests
{
    [Fact]
    public void Analisar_Triangulo345_RetornaAnaliseCompleta()
    {
        // Arrange
        double a = 3.0;
        double b = 4.0;
        double c = 5.0;

        // Act
        var resultado = AnalisadorTriangulo.Analisar(a, b, c);

        // Assert
        Assert.Equal(TipoTriangulo.Escaleno, resultado.Tipo);
        Assert.Equal(TipoPorAngulo.Retangulo, resultado.TipoPorAngulo);
        Assert.Equal(12.0, resultado.Perimetro);
        Assert.Equal(6.0, resultado.Area);
        Assert.Equal(36.87, resultado.Angulos.A);
        Assert.Equal(53.13, resultado.Angulos.B);
        Assert.Equal(90.0, resultado.Angulos.C);
    }

    [Theory]
    [InlineData(1.0, 2.0, 3.0)]
    [InlineData(1.0, 2.0, 4.0)]
    [InlineData(0.0, 2.0, 2.0)]
    [InlineData(-1.0, 2.0, 2.0)]
    public void Analisar_TrianguloInvalido_LancaTrianguloInvalidoException(
        double a, double b, double c)
    {
        // Arrange
        // Dados recebidos pelo Theory

        // Act + Assert
        Assert.Throws<TrianguloInvalidoException>(
            () => AnalisadorTriangulo.Analisar(a, b, c));
    }
    
    [Fact]
    public void Classificar_PermutacaoDosLados_MantemClassificacao()
    {
        // Arrange
        var esperado = TipoTriangulo.Isosceles;
    
        var permutacoes = new[]
        {
            (2.0, 2.0, 3.0),
            (2.0, 3.0, 2.0),
            (3.0, 2.0, 2.0)
        };
    
        // Act + Assert
        foreach (var (a, b, c) in permutacoes)
        {
            var resultado = ClassificadorTriangulo.Classificar(a, b, c);
            Assert.Equal(esperado, resultado);
        }
    }
}