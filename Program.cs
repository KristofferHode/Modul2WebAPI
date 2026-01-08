using Modul2WEBAPI;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<VideoGameCsvRepository>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<VideoGameCsvRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapControllers();

app.Run();