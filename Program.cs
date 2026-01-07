

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

builder.Services.AddSingleton<VideoGameRepository>();
builder.Services.AddControllers();

app.MapControllers();
namespace Modul2WEBAPI
{
    
}
