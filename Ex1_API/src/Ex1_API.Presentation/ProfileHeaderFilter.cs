using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ex1_API.Presentation
{
    public class ProfileHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Profile",
                In = ParameterLocation.Header,
                Required = true,
                Example = new OpenApiString("Ada")
            });
        }
    }
}
