using Microsoft.EntityFrameworkCore;
using Practica5_ProyectoVenta.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//-----------------------------------------------------------------------------------------

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

//configuracion para la cadena de conexion
builder.Services.AddDbContext<ProyectoVentaContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("QuerySql")));

builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

//-----------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=GenerarVenta}/{action=IndexVenta}/{id?}");

app.Run();
