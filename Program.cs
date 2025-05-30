using firstApi.Mappers;
using firstApi.Models;
using Microsoft.EntityFrameworkCore;
using SwaggerThemes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();



builder.Services.AddScoped<IProductMapper, ProductMapper>();
// sql yok pcde
builder.Services.AddDbContext<ApiDbContext>(opt =>
{
    string key =
        "Data Source=localhost;Database = apiDb;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0";
    var connectionString = key;
    opt.UseSqlServer(connectionString);
});

var app = builder.Build();
app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(Theme.UniversalDark);
}

app.UseHttpsRedirection();



app.Run();

