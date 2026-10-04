using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Triangulos.Tests.Api;

public class TriangulosApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TriangulosApiTests(WebApplicationFactory<Program> factory)
        => _client = factory.CreateClient();

    [Fact]
    public async Task Health_RequisicaoValida_Retorna200()
    {
        // Act
        var resposta = await _client.GetAsync("/health");

        // Assert
        Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
    }

    [Fact]
    public async Task Classificar_Triangulo345_Retorna200Escaleno()
    {
        // Act
        var resposta = await _client.GetAsync(
            "/api/triangulos/classificar?a=3&b=4&c=5");

        var json = await resposta.Content.ReadFromJsonAsync<JsonElement>();

        // Assert
        Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        Assert.Equal("Escaleno", json.GetProperty("tipo").GetString());
    }

    [Fact]
    public async Task Classificar_TrianguloInexistente_Retorna200NaoEhTriangulo()
    {
        // Act
        var resposta = await _client.GetAsync(
            "/api/triangulos/classificar?a=1&b=2&c=4");

        var json = await resposta.Content.ReadFromJsonAsync<JsonElement>();

        // Assert
        Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        Assert.Equal("NaoEhTriangulo", json.GetProperty("tipo").GetString());
    }

    [Fact]
    public async Task Classificar_ParametroAusente_Retorna400()
    {
        // Act
        var resposta = await _client.GetAsync(
            "/api/triangulos/classificar?a=3&b=4");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, resposta.StatusCode);
    }

    [Fact]
    public async Task Classificar_ParametroNaoNumerico_Retorna400()
    {
        // Act
        var resposta = await _client.GetAsync(
            "/api/triangulos/classificar?a=abc&b=4&c=5");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, resposta.StatusCode);
    }

    [Fact]
    public async Task Analisar_Triangulo345_Retorna200ComAnalise()
    {
        // Arrange
        var corpo = new { a = 3.0, b = 4.0, c = 5.0 };

        // Act
        var resposta = await _client.PostAsJsonAsync(
            "/api/triangulos/analisar", corpo);

        var json = await resposta.Content.ReadFromJsonAsync<JsonElement>();

        // Assert
        Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        Assert.Equal("Escaleno", json.GetProperty("tipo").GetString());
        Assert.Equal("Retangulo", json.GetProperty("tipoPorAngulo").GetString());
        Assert.Equal(12.0, json.GetProperty("perimetro").GetDouble());
        Assert.Equal(6.0, json.GetProperty("area").GetDouble());
    }

    [Fact]
    public async Task Analisar_TrianguloInvalido_Retorna422()
    {
        // Arrange
        var corpo = new { a = 1.0, b = 2.0, c = 4.0 };

        // Act
        var resposta = await _client.PostAsJsonAsync(
            "/api/triangulos/analisar", corpo);

        // Assert
        Assert.Equal(HttpStatusCode.UnprocessableEntity, resposta.StatusCode);
    }

    [Fact]
    public async Task Analisar_JsonMalformado_Retorna400()
    {
        // Arrange
        var corpo = new StringContent(
            "{\"a\":3,\"b\":4,",
            Encoding.UTF8,
            "application/json");

        // Act
        var resposta = await _client.PostAsync(
            "/api/triangulos/analisar", corpo);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, resposta.StatusCode);
    }
}