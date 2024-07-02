using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskManager.Data;
using TaskManager.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskDb>();

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

app.MapPost("/tasks", async (TaskDb db, TaskObj task) => 
{
  await db.Tasks.AddAsync(task);
  await db.SaveChangesAsync();
  return Results.Created($"/task/{task.Id}", task);
});

app.MapPost("/folders", async (TaskDb db, Folder folder) =>
{
  await db.Folders.AddAsync(folder);
  await db.SaveChangesAsync();
  return Results.Created($"/folders/{folder.FolderId}", folder);
});

app.MapGet("/tasks", async (TaskDb db) => await db.Tasks.ToListAsync());

app.MapGet("/tasks/{id}", async (TaskDb db, int id) =>
{
  TaskObj task = await db.Tasks.FindAsync(id);
  if (task is null) return Results.NotFound();
  return Results.Ok(task);
});

app.MapGet("/folders", async (TaskDb db) => await db.Folders.ToListAsync());

app.MapGet("/folders/{folderId}", async (TaskDb db, int folderId) =>
{
  Folder folder = await db.Folders.FindAsync(folderId);
  if (folder is null) return Results.NotFound();
  return Results.Ok(folder);
});

app.MapPut("/tasks/{id}", async (TaskDb db, TaskObj newTask, int id) =>
{
  TaskObj task = await db.Tasks.FindAsync(id);
  if (task is null) return Results.NotFound();

  task.Title = newTask.Title;
  task.Description = newTask.Description;
  task.DueDate = newTask.DueDate;
  task.FolderId = newTask.FolderId;
  task.Folder = newTask.Folder;

  await db.SaveChangesAsync();
  return Results.NoContent();
});

app.MapPut("/folders/{folderId}", async (TaskDb db, Folder newFolder, int folderId) =>
{
  Folder folder = await db.Folders.FindAsync(folderId);
  if (folder is null) return Results.NotFound();

  folder.Title = newFolder.Title;

  await db.SaveChangesAsync();
  return Results.NoContent();
});

app.MapDelete("/tasks/{id}", async (TaskDb db, int id) =>
{
  TaskObj task = await db.Tasks.FindAsync(id);
  if (task is null) return Results.NotFound();

  db.Tasks.Remove(id);
  await db.SaveChangesAsync();
  return Results.NoContent();
});

app.MapDelete("/folders/{folderId}", async(TaskDb db, int folderId) =>
{
  Folder folder = await db.Folders.FindAsync(folderId);
  if (folder is null) return Results.NotFound();

  db.Folders.Remove(folderId);
  await db.SaveChangesAsync();
  return Results.NoContent();
});

app.Run();
