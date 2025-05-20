using ListaCompra.Data;
using ListaCompra.Profile;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//

var connectionString = builder.Configuration.GetConnectionString("ListaConnection");

builder.Services.AddDbContext<ProdutoContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddAutoMapper(typeof(ProdutoProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
