using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;
using ToDoAPI.Enities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnectionString"))
    );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getToDos", (ToDoContext db) =>
{
    var tasks = db.ToDoTasks;
    return Results.Ok(tasks);
})
 .WithName("GetTasks")
 .WithOpenApi();

app.MapPost("/addtask", (ToDoContext db, ToDoItem todoitem) =>
{
    var tasks = db.ToDoTasks;
    db.ToDoTasks.Add(todoitem);
    db.SaveChanges();
    return Results.Created($"/pets/{todoitem.Id}", todoitem);
})
    .WithName("AddTask")
    .WithOpenApi();

app.MapDelete("/rmvtask/{id}", (int id, ToDoContext db) =>
{
    var tasks = db.ToDoTasks;
    var taskEntity = db.ToDoTasks.SingleOrDefault(p => p.Id == id);
    if (taskEntity == null)
        return Results.NotFound();


    tasks.Remove(taskEntity);
    db.SaveChanges();
    return Results.NoContent();
})
    .WithName("RemoveTask")
    .WithOpenApi();


app.Run();


