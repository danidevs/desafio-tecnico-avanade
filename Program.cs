using Microsoft.EntityFrameworkCore;
using ServicoDeEstoque.Data;
using ServicoDeEstoque.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext com banco em memória
builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseInMemoryDatabase("StockDb"));

// Adiciona controllers
builder.Services.AddControllers();

// Swagger para testar API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
