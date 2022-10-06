using Mint.Domain.BindingModels;
using Mint.Domain.Exceptions;
using Mint.Infrastructure;
using System.Net;
using System.Text.Json;

namespace Mint.Api.Services;

public class ExceptionHandlingEtensions
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingEtensions> _logger;
    private readonly ApplicationDbContext _context;

    public ExceptionHandlingEtensions(
        RequestDelegate next,
        ILogger<ExceptionHandlingEtensions> logger, 
        ApplicationDbContext context)
    {
        _next = next;
        _logger = logger;
        _context = context;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ContentNotFoundException ex)
        {
            await HandleExceptionAsync(
                httpContext: httpContext,
                message: ex.Message,
                code: HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(
                httpContext: httpContext,
                message: ex.Message,
                code: HttpStatusCode.BadRequest);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, string message, HttpStatusCode code)
    {
        _logger.LogError(message, code);

        var response = httpContext.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)code;

        var error = new ErrorBindigModel()
        {
            Message = message,
            StatucCode = (int)code,
        };

        var result = JsonSerializer.Serialize(error);
        await response.WriteAsync(result);
    }
}
