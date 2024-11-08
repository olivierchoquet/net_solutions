using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Northwind_API
{
    public class SwaggerSchemaFilter : ISchemaFilter
    {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {

            foreach (var item in context.SchemaRepository.Schemas.Keys)
            {
                if (!item.EndsWith("DTO")) context.SchemaRepository.Schemas.Remove(item);
            }

            context.SchemaRepository.Schemas.Remove("Void");

        }
    }
}