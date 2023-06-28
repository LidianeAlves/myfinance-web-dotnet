using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
namespace myfinance_web_dotnet
{
    public class MyFinanceDbController:DbContext
    {
        public DbSet<PlanoConta> PlanoConta {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(
            @"Server=PE07AV2C\SQLEXPRESS;Database=myfinance;Trusted_Connection=True;TrustServerCertificate"
        );
        }
    }
}