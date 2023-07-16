using MySql.Data.MySqlClient;
using System;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet
{
    public class MyFinanceDbController:DbContext
    {
        public DbSet<PlanoConta> PlanoConta {get; set;}
        public DbSet<Transacao> Transacao {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql(
            "server=localhost;port=3306;database=my-finance;user=root;password=root",
            new MySqlServerVersion(new Version(8, 0, 11))
        );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>()
            .ToTable("Transacao")
            .Property(x => x.PlanoContaId)
            .HasColumnName("PlanoConta_Id");
        }
    }
}