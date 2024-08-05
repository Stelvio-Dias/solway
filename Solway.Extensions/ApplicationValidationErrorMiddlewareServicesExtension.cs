using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Solway.Errors;
using Microsoft.Extensions.Logging;

namespace Solway.Extensions;

public static class ApplicationValidationErrorMiddlewareServicesExtension
{
    private static readonly ILogger<string>? _logger;

    public static IServiceCollection AddValidationErrorMiddleware(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(config =>
        {
            config.InvalidModelStateResponseFactory = actionContext =>
            {
                List<string> errors = actionContext.ModelState
                    .Where(e => e.Value?.Errors.Count > 0)
                    .SelectMany(e => e.Value!.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ApiValidationErrorResponse errorResponse = new ApiValidationErrorResponse
                {
                    Errors = errors
                };

                //_logger.LogCritical(errors.ToString());

                return new BadRequestObjectResult(errorResponse);
            };
        });

        return services;
    }
}