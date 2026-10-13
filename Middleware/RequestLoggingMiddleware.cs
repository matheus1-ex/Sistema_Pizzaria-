using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SistemaPizza.Middleware;

public sealed class RequestLoggingMiddleware
{
    private readonly RequestDelegate _proximo;
    private readonly ILogger<RequestLoggingMiddleware> _logger;
    public RequestLoggingMiddleware(
        RequestDelegate proximo,
        ILogger<RequestLoggingMiddleware> logger
    )
    {
        _proximo = proximo;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext contexto)
    {
        var inicio = Stopwatch.GetTimestamp();

        _logger.LogInformation(
            "Iniciando {Metodo} {Caminho}",
            contexto.Request.Method,
            contexto.Request.Path  
        );

        try
        {
            await _proximo(contexto);
        }

        finally
        {
            var duracao = Stopwatch.GetElapsedTime(inicio);
            _logger.LogInformation
            (
                "HTTP {Method} {Path} respondeu {StatusCode} em {Duracao}ms",
                contexto.Request.Method,
                contexto.Request.Path,
                contexto.Response.StatusCode,
                duracao.TotalMilliseconds
            );
        }
    }
}