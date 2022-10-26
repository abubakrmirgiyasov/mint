using Mint.Domain.BindingModels;
using Mint.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Mint.Api.Services;

public class ExceptionHandlingEtensions
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingEtensions> _logger;

    public ExceptionHandlingEtensions(
        RequestDelegate next,
        ILogger<ExceptionHandlingEtensions> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            switch (ex)
            {
                case ForbiddenException e:
                    await HandleExceptionAsync(
                        httpContext: httpContext,
                        message: e.Message,
                        code: HttpStatusCode.BadRequest);
                    break;
                case ContentNotFoundException e:
                    await HandleExceptionAsync(
                        httpContext: httpContext,
                        message: e.Message,
                        code: HttpStatusCode.BadGateway);
                    break; 
                case SimilarUserException e:
                    await HandleExceptionAsync(
                        httpContext: httpContext,
                        message: e.Message,
                        code: HttpStatusCode.BadRequest);
                    break;
                case UserBlockedException e:
                    await HandleExceptionAsync(
                        httpContext: httpContext,
                        message: e.Message,
                        code: HttpStatusCode.NoContent);
                    break;
                default:
                    await HandleExceptionAsync(
                        httpContext: httpContext,
                        message: ex.Message,
                        code: HttpStatusCode.BadRequest);
                    break;
            }
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
