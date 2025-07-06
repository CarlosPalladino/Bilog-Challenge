using Microsoft.EntityFrameworkCore;

public class EspecialidadMiddlewares
{
    private readonly RequestDelegate _next;
    private readonly ILogger<EspecialidadMiddlewares> _logger;



    public EspecialidadMiddlewares(RequestDelegate next, ILogger<EspecialidadMiddlewares> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";

            var statusCode = ex switch
            {
                DbUpdateConcurrencyException => StatusCodes.Status409Conflict,
                KeyNotFoundException => StatusCodes.Status404NotFound,

                ArgumentException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
            context.Response.StatusCode = statusCode;

            var respuestaErrada = new
            {
                status = statusCode,
                message = ex.Message
            };

            await context.Response.WriteAsJsonAsync(respuestaErrada);
        }
    }
}


