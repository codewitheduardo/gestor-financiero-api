using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sistema.LogicaAccesoDatos;
using Sistema.LogicaAccesoDatos.Repositorios;
using Sistema.LogicaAplicacion.CasosUso.CUMovimiento;
using Sistema.LogicaAplicacion.CasosUso.CUServicios;
using Sistema.LogicaAplicacion.CasosUso.CUTipoGasto;
using Sistema.LogicaAplicacion.CasosUso.CUTipoIngreso;
using Sistema.LogicaAplicacion.CasosUso.CUUsuario;
using Sistema.LogicaAplicacion.ICasosUso.ICUMovimiento;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoIngreso;
using Sistema.LogicaAplicacion.ICasosUso.ICUUsuario;
using Sistema.LogicaAplicacion.ICasosUso.IServicios;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión (desde appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT
//La clave está en el appsettings.json
var jwt = builder.Configuration["Jwt:Key"]!;
var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        //Definir las verificaciones a realizar
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = claveCodificada
    };
});

builder.Services.AddHttpClient<ICotizacionMonedaService, CotizacionMonedaService>();

//ID REPOSITORIOS
builder.Services.AddScoped<IRepositorioMovimiento, RepositorioMovimiento>();
builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGasto>();
builder.Services.AddScoped<IRepositorioTipoIngreso, RepositorioTipoIngreso>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

//ID de los casos de uso
builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
builder.Services.AddScoped<ICULogin, CULogin>();
builder.Services.AddScoped<ICUAltaTipoGasto, CUAltaTipoGasto>();
builder.Services.AddScoped<ICUEditarTipoGasto, CUEditarTipoGasto>();
builder.Services.AddScoped<ICUEliminarTipoGasto, CUEliminarTipoGasto>();
builder.Services.AddScoped<ICUObtenerTipoGasto, CUObtenerTipoGasto>();
builder.Services.AddScoped<ICUObtenerTipoGastos, CUObtenerTipoGastos>();
builder.Services.AddScoped<ICUObtenerTipoGastosActivos, CUObtenerTipoGastosActivos>();
builder.Services.AddScoped<ICUAltaTipoIngreso, CUAltaTipoIngreso>();
builder.Services.AddScoped<ICUEditarTipoIngreso, CUEditarTipoIngreso>();
builder.Services.AddScoped<ICUEliminarTipoIngreso, CUEliminarTipoIngreso>();
builder.Services.AddScoped<ICUObtenerTipoIngreso, CUObtenerTipoIngreso>();
builder.Services.AddScoped<ICUObtenerTipoIngresos, CUObtenerTipoIngresos>();
builder.Services.AddScoped<ICUObtenerTipoIngresosActivos, CUObtenerTipoIngresosActivos>();
builder.Services.AddScoped<ICUAltaMovimiento, CUAltaMovimiento>();
builder.Services.AddScoped<ICUObtenerMovimientos, CUObtenerMovimientos>();
builder.Services.AddScoped<ICUObtenerCotizacionUYU, CUObtenerCotizacionUYU>();
builder.Services.AddScoped<ICUObtenerMovimientosPorMesAnio, CUObtenerMovimientosPorMesAnio>();
builder.Services.AddScoped<ICUEliminarMovimieno, CUEliminarMovimiento>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
