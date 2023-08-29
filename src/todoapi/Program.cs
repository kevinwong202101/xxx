using Microsoft.EntityFrameworkCore;
using todoapi.Data;
using todoapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("memdb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/todo", async (AppDbContext db) => {
var items = await db.ToDoItems.ToListAsync();
return Results.Ok(items);
});

app.MapPost("api/todo", async (AppDbContext db, ToDoItem todoItem) => {
await db.ToDoItems.AddAsync(todoItem);
await db.SaveChangesAsync();

return Results.Created($"api/todo/{todoItem.Id}", todoItem);

});
app.Run();
