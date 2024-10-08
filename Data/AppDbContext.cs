namespace PizzaStoreApi.Data;

using Microsoft.EntityFrameworkCore;
using PizzaStoreApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Pizza> Pizzas { get; set; } = null!;
}