using Microsoft.EntityFrameworkCore;
namespace API.Models;

public class AppDataContext : DbContext
{

public DbSet<Cliente> tabCliente { get; set; }
public DbSet<Funcionario> tabFuncionario { get; set; }
public DbSet<Eventos> tabEventos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=BancoBalada.db");
    }



}