using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskManager.Data;
using TaskManager.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("tasks") ?? "Data Source = tasks.db";
builder.Services.AddDbContext<TaskDb>(options => options.UseSqlite(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tasks API", Description = "Api for a task management application", Version = "v1" });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API V1");
  });
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/task", async(TaskDb db) => await db.Tasks.ToListAsync());

app.MapPost("/task", async(TaskDb db, TaskObj task)  => {
  await db.Tasks.AddAsync(task);
  await db.SaveChangesAsync();
  return Results.Created($"/task/{task.Id}", task);
});

app.Run();
