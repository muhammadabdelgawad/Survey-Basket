using SurveyBasket.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);


var app = builder.Build(); 

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>options.SwaggerEndpoint("/openapi/v1.json", "v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
