using Microsoft.EntityFrameworkCore;
using WebApiRecargas.Contexts;
using WebApiRecargas.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS para permitir cualquier origen, método y encabezado
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Agregar controladores
//builder.Services.AddControllers();

//var app1 = builder.Build();

//app1.UseHttpsRedirection();

//app1.UseAuthorization();

////app1.MapControllers();

//app1.Run();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ConexionSqlServer>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer"));
});


//builder.Services.AddSingleton(new MySqlConfiguration(builder.Configuration.GetConnectionString("MySqlConection")));

builder.Services.AddScoped<IVentaTotalRepository, VentaTotalRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

// Aplicar la política de CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
