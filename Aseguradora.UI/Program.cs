using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Aseguradora.UI.Data;
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddTransient<ListarPolizasUseCase>();
builder.Services.AddTransient<AgregarPolizaUseCase>();
builder.Services.AddTransient<EliminarPolizaUseCase>();
builder.Services.AddTransient<ModificarPolizaUseCase>();
builder.Services.AddTransient<ObtenerPolizaUseCase>();
builder.Services.AddScoped<IRepoPoliza,RepoPolizas>();

builder.Services.AddTransient<ListarTitularesUseCase>();
builder.Services.AddTransient<AgregarTitularUseCase>();
builder.Services.AddTransient<ModificarTitularUseCase>();
builder.Services.AddTransient<EliminarTitularUseCase>();
builder.Services.AddTransient<ObtenerTitularUseCase>();
builder.Services.AddScoped<IRepoTitular,RepoTitulares>();

builder.Services.AddTransient<ListarSiniestrosUseCase>();
builder.Services.AddTransient<AgregarSiniestroUseCase>();
builder.Services.AddTransient<ModificarSiniestroUseCase>();
builder.Services.AddTransient<EliminarSiniestroUseCase>();
builder.Services.AddTransient<ObtenerSiniestroUseCase>();
builder.Services.AddScoped<IRepoSiniestro,RepoSiniestro>();

builder.Services.AddTransient<ListarVehiculosUseCase>();
builder.Services.AddTransient<ListarVehiculosCondUseCase>();
builder.Services.AddTransient<AgregarVehiculoUseCase>();
builder.Services.AddTransient<ModificarVehiculoUseCase>();
builder.Services.AddTransient<EliminarVehiculoUseCase>();
builder.Services.AddTransient<ObtenerVehiculoUseCase>();
builder.Services.AddScoped<IRepoVehiculo,RepoVehiculo>();

builder.Services.AddTransient<ListarTercerosUseCase>();
builder.Services.AddTransient<AgregarTerceroUseCase>();
builder.Services.AddTransient<EliminarTerceroUseCase>();
builder.Services.AddTransient<ModificarTerceroUseCase>();
builder.Services.AddTransient<ObtenerTerceroUseCase>();
builder.Services.AddScoped<IRepoTercero,RepoTerceros>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
