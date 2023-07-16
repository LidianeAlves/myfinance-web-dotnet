using MySql.Data.MySqlClient;
using System;
using myfinance_web_dotnet;
using myfinance_web_dotnet.Application.ObterPlanoContaUseCase;
using myfinance_web_dotnet.Services.Interfaces;
using myfinance_web_dotnet.Repository.Interfaces;
using myfinance_web_dotnet.Repository;
using myfinance_web_dotnet.Service.PlanoContaService;
using myfinance_web_dotnet.Application.CadastrarPlanoContaUseCase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyFinanceDbController>();
builder.Services.AddScoped<IObterPlanoContaUseCase,ObterPlanoContaUseCase>();
builder.Services.AddScoped<ICadastrarPlanoContaUseCase,CadastrarPlanoContaUseCase>();
builder.Services.AddScoped<IPlanoContaService,PlanoContaService>();
builder.Services.AddScoped<IPlanoContaRepository,PlanoContaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// // Conexão com o banco de dados MySQL
//         string connectionString = "server=localhost;port=3306;database=my-finance;user=root;password=root;";
//         using (var connection = new MySqlConnection(connectionString))
//         {
//             connection.Open();

//             // Exemplo de consulta SELECT
//             string query = "SELECT * FROM transacao";
//             using (var command = new MySqlCommand(query, connection))
//             {
//                 using (var reader = command.ExecuteReader())
//                 {
//                     while (reader.Read())
//                     {
//                         // Ler os dados do resultado da consulta
//                         int id = reader.GetInt32("id");
//                         string historico = reader.GetString("historico");
//                         string tipo = reader.GetString("tipo");
//                         decimal valor = reader.GetDecimal("valor");
//                         string data = reader.GetString("data");
//                         string planoDeContasId = reader.GetString("planoDeContasId");

//                         // Fazer o que for necessário com os dados obtidos
//                         Console.WriteLine($"ID: {id}, historico: {historico},tipo: {tipo}, Valor: {valor}");
//                     }
//                 }
//             }
//         }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
