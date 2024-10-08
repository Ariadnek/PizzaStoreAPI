using Microsoft.EntityFrameworkCore;
using PizzaStoreApi.Data;
using PizzaStoreApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options=> options.UseInMemoryDatabase("pizzadb"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/pizzas", async(AppDbContext db) => await db.Pizzas.ToListAsync());

app.MapPost("/pizza", async (AppDbContext db, Pizza pizza) =>
{
  await db.Pizzas.AddAsync(pizza);
  await db.SaveChangesAsync();
  return Results.Created($"/pizza/{pizza.Id}", pizza);
});

app.Run();
