using EgretApi;
using EgretApi.DataAccessLayer;
using EgretApi.Services.Geospatial;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

builder.Services.AddDbContextPool<GeospatialContext>(o => o.UseSqlServer(startup.DbConnectionString));

// Add services to the container.
builder.Services.AddScoped<IGeospatialService, GeospatialService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
