using Microsoft.AspNetCore.HttpLogging;
using Northwind_API;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096;
    options.ResponseBodyLogLimit = 4096;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
    {
        c.SwaggerDoc("v1", new() { Title = "Northwind API", Version = "v1", Description = "Northwind API By Olivier Choquet" });
        c.SchemaFilter<SwaggerSchemaFilter>();
 
    });

var app = builder.Build();

app.UseHttpLogging();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



