using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

public class HideEndpointsFilter : IDocumentFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HideEndpointsFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext == null || httpContext.User?.Identity?.IsAuthenticated != true)
        {
            var pathsToRemove = swaggerDoc.Paths
                .Where(path => !path.Key.Contains("/api/User/login"))
                .ToList();

            foreach (var path in pathsToRemove)
            {
                swaggerDoc.Paths.Remove(path.Key);
            }
        }
    }
}
