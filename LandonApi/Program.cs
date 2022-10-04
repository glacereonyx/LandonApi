using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ApiVersionReader = new MediaTypeApiVersionReader();
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseOpenApi();
    app.UseSwaggerUi3();
    //app.UseReDoc();
};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
