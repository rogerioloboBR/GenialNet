using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProdutoFornecedorAPI.Data;
using ProdutoFornecedorAPI.Integration.Interfaces;
using ProdutoFornecedorAPI.Integration.Refit;
using ProdutoFornecedorAPI.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<ViaCepService>();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c => 
{
    c.BaseAddress = new Uri("https://viacep.com.br");
});
builder.Services.AddScoped<IViaCepIntegration, ViaCepService>();
var app = builder.Build();

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