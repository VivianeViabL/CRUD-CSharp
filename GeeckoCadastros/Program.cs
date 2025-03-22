using System.Numerics;
using System.Data.SqlClient;
using GeeckoCadastros.BancoDados;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GeeckoCadastrosContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Caso der ruim o "Data", colocar de volta:  
//Retirado -> "Data Source=DESKTOP-NR3V7RK\\SQLSERVER;Initial Catalog=Produtos;Integrated Security=True;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=True;TrustServerCertificate=True"
//Sugestão YouTube Database=myDataBase;Trusted_Connection=True

builder.Services.Configure<MvcOptions>(options => // "Serviço" adicionando por conta da mensagem de erro "The field Valor must be a number." 
{
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
        _ => "Por favor, insira um número válido."
    );
});

var app = builder.Build(); // O método "builder.Build()" finaliza a configuração do aplicativo e trava a coleção de serviços

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

var defaultCulture = new CultureInfo("pt-BR"); // Cultura global, adicionada devido ao erro do campo "Valor" no site -> "The field Valor must be a number." 
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
