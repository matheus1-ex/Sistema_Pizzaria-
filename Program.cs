using System.Text;
using System.Text.Json.Serialization;
using SistemaPizza.Data;
using Microsoft.OpenApi;
using SistemaPizza.Controllers;
using SistemaPizza.DTOs;
using SistemaPizza.Models;
using Microsoft.EntityFrameworkCore;
using SistemaPizza.Services;
using SistemaPizza.Middleware;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Conexão com o banco de dados (Sql Server)
        string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connection)
        );

        //Conversão de Enums para Strings
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        //Configuração do swagger
        builder.Services.AddEndpointsApiExplorer();

        //Injeção de dependência
        builder.Services.AddScoped<IClienteService, ClienteService>();
        builder.Services.AddScoped<IEntregadorService, EntregadorService>();
        builder.Services.AddScoped<IProdutoService, ProdutoService>();
        builder.Services.AddScoped<IPedidoService, PedidoService>();
        builder.Services.AddScoped<IItemVendidoService, ItemVendidoService>();

        var app = builder.Build();
         Console.WriteLine($"O SQL Server está sendo gravado em {System.IO.Path.GetFullPath("sistemapizza.db")}");

         using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();
        }

        //Middlewares

        app.UseMiddleware<RequestLoggingMiddleware>();

        app.UseRouting();
        app.MapGet("/", () => Results.Redirect("/swagger"));
        app.MapControllers();
        app.Run();


    }
}

