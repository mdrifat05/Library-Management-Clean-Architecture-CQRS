using LibraryManagement.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;
using Serilog;

namespace LibraryManagement.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        string result = JsonConvert.SerializeObject(new ErrorDeatils
        {
            ErrorMessage = exception.Message,
            ErrorType = "Failure"
        });

        _logger.LogError(result);

        switch (exception)
        {
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                break;
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(validationException.Errors);
                break;
            case NotFoundException notFoundException:
                statusCode = HttpStatusCode.NotFound;
                break;
            default:
                break;
        }

        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);
    }
}

public class ErrorDeatils
{
    public string ErrorType { get; set; }
    public string ErrorMessage { get; set; }
}
