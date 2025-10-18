using Adboard.AppServices.Exceptions;
using Adboard.Contracts.Errors;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Adboard.Infrastructure.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var errorModel = MapError(context, exception);
        context.Response.StatusCode = errorModel.Item1;
        
        logger.LogError("Error occured: {ErrorDto}", JsonConvert.SerializeObject(errorModel.Item2));
        
        return context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel.Item2));
    }
    
    // Todo: добавить обработку ошибок о валидациях
    private static (int, ErrorDto) MapError(HttpContext context, Exception exception) =>
        exception switch
        {
            NotFoundException e => (StatusCodes.Status404NotFound, new ErrorDto
            {
                StatusCode = StatusCodes.Status404NotFound,
                Message = $"Entity not found error: {e.NotFoundMessage}",
                TraceId = context.TraceIdentifier
            }),
            
            AlreadyExistsException e => (StatusCodes.Status409Conflict, new ErrorDto
            {
               StatusCode = StatusCodes.Status409Conflict,
               Message = $"Entity already exist: {e.AlreadyExistMessage}",
               TraceId = context.TraceIdentifier
            }),
            
            ArgumentException e => (StatusCodes.Status400BadRequest, new ErrorDto
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = $"Argument error: {e.Message}",
                TraceId = context.TraceIdentifier
            }),
            
            SecurityTokenValidationException e => (StatusCodes.Status400BadRequest, new ErrorDto
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = $"Token validation error: {e.Message}",
                TraceId = context.TraceIdentifier
            }),
            
            DbUpdateException e => (StatusCodes.Status400BadRequest, new ErrorDto
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Database update error, try again later.",
                TraceId = context.TraceIdentifier
            }),
            
            _ => (StatusCodes.Status500InternalServerError, new ErrorDto
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Internal server error, try again later.",
                TraceId = context.TraceIdentifier
            })
        };
}