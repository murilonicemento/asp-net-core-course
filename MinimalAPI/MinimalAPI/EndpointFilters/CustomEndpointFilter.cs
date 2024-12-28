using System.ComponentModel.DataAnnotations;
using MinimalAPI.Models;

namespace MinimalAPI.EndpointFilters;

public class CustomEndpointFilter : IEndpointFilter
{
    private readonly ILogger<CustomEndpointFilter> _logger;

    public CustomEndpointFilter(ILogger<CustomEndpointFilter> logger)
    {
        _logger = logger;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        _logger.LogInformation("Before logic");

        var product = context.Arguments.OfType<Product>().FirstOrDefault();

        if (product is null) return Results.BadRequest("Product details not found in the request");

        var validationContext = new ValidationContext(product);
        var errors = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(product, validationContext, errors, true);

        if (!isValid) return Results.BadRequest(errors.FirstOrDefault()?.ErrorMessage);

        var result = await next(context);

        // After logic
        _logger.LogInformation("After logic");

        return result;
    }
}