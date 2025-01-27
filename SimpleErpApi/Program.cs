using Microsoft.EntityFrameworkCore;
using SimpleErpApi.Services;
using SimpleErpApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SimpleErpContext>(options =>
	options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<INotaFiscalService, NotaFiscalService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICalculoImpostoService, CalculoImpostoService>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowLocalFrontEnd", policy =>
	{
		policy.WithOrigins("http://localhost:4200")
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseCors("AllowLocalFrontEnd");
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
