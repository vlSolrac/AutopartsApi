using ProductsApi.Interfaces;
using ProductsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var am = builder.Configuration.GetValue<String>("Ambient");
var x = "Production";
if (am == "dev") x = "Development";

builder.Services.AddControllers();
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategory, CategotyService>();
builder.Services.AddScoped<IModel, ModelService>();
builder.Services.AddScoped<ICarComponent, CarComponentService>();
builder.Services.AddScoped<ICar, CarService>();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

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
