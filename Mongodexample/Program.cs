using Mongodexample.Models;
using Mongodexample.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    options.AddPolicy(name: "AllowAnyOrigin", builder => builder.AllowAnyOrigin())
);


// Add services to the container.
builder.Services.Configure<FoodStoreDatabaseSettings>(
    builder.Configuration.GetSection("FoodStoreDatabase"));

builder.Services.AddSingleton<FoodService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();