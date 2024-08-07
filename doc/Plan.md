# Task Manager API development Plan

## Requirements Analysis

* Requirements
  * As a user, I should be able to create an account
  * As a user, I should be able to log into my account
  * As a user, I should be able to create, read, update, and delete tasks
  * As a user, I should be able to filter and search for tasks
  * As a user, I should be able to create and delete folders
  * As a user, I should be able to organize my tasks in different folders
  * As a user, I should be able to move a task to a different folder
* What does a good solution look like?
  * Users can create and log into their acccount
    * Method of authentication is secure
  * Users can create, read, update, and delete tasks
    * Tasks are held in a database when created
    * That database is updated when the task is
    * Tasks that are deleted are removed from the database
  * Users can create and delete folders
    * Folders that are created are stored in a database
    * Folders that are deleted are removed from the database
  * Users can store tasks in folders
    * The relationship between folders and tasks are many to one
      * One folder has many tasks
      * A task can be stored in one folder
  * Users can filter tasks
    * Filter by folder
    * Filter by due date
  * Users can search for tasks
    * Should be able to filter their search
* What I know
  * What I already know how to do
    * Create endpoints in .NET
  * What I don't know how to do
    * Instantiate and use models in .NET
    * Implement authentication in .NET
  * How I will learn what I don't know
    * Read documentation
    * Take a tutorial course
* Data used by the prgram
  * Request methods - string
    * Used to determine the kind of action that needs to be performed
  * Request url - string
    * Used to map to the proper endpoint
  * Request headers - string
    * Used to transfer additional data needed by the endpoint
  * Request body - string
    * Used when an endpoint is supposed to do something to data
* Algorithms that will be needed
  * Algorithm to take data and create a task
  * Algorithm to take data and update a task
  * Algorithm to fetch multiple tasks (filtered or unfiltered)
  * Algorithm to fetch a specific task
  * Algorithm to delete a specific task
  * Algorithm to create a folder
  * Algortihm to delete a folder (and all of the tasks inside the folder)
  * Algortihm to add a task to a folder
  * Algorithm to create an account
  * Algorithm to log into an account

## Design

### Models

#### `Task.cs`

* This is the model for a task
* Will have a many to one relationship with the `Folder` model
* Will have five fields
  1. `Id` - int
    * The id number for the task
  2. `Title` - string
    * The name of the task
  3. `Description` - string
    * A brief description of the task, including any notes pertaining to it
  4. `FolderId` - int
    * Foreign key for the cooresponding `Folder`
  5. `Folder` - Folder
    * Reference navigation to cooresponding `Folder`
* The `Id` and `Name` are required fields, but the description can be nullible

```cs
namespace Task.Models
{
  public class Task
  {
    public int Id
    public string Title
    public nullable string Description
    public int FolderId
    public Folder Folder
  }
}
```

#### `Folder.cs`

* This model represents a folder, which can hold many tasks
* Will have a many to one relationship with the `Task` model
* Will have three fields
  1. `Id` - int
    * The id number for the folder
  2. `Title` - string
    * The name of the folder
  3. `Tasks` - List<Task>
    * The list of tasks held in that folder

```cs

namespace Folder.Model
{
  public class Folder
  {
    public int Id
    public string Title
    public List<Task> Tasks
  }
}
```

#### `TasksDb.cs`

* Works as the database context for the program

```cs
using Task.Models
using EntityFrameworkCore

namespace TaskManager.Data

public class TaskDb : DbContext
{
  public DbSet<Task> Tasks { get and set }
  public DbSet<Folder> Folders { get and set }
}
```

### Endpoints

The API will use the following endpoints

* Get Tasks
  * An endpoint that returns all tasks in the database
* Get Task
  * An enpoint that returns a single task
* Get Folders
  * An endpoint that returns all folders in the database
* Get Folder
  * An endpoint that returns all the tasks from a certain folder
* Post Task
  * An endpoint that creates a task
* Post Folder
  * An endpoint that creates a folder
* Put Task
  * An endpoint that updates a task
* Put Folder
  * An endpoint that updates a folder
* Delete Task
  * An endpoint that deletes a task
* Delete Folder
  * An endpoint that deletes a folder and all the tasks in it

#### Get Tasks

* This endpoint returns all Tasks in the database
* Must be done asynchronously, as the API has to wait for the data
* URI - "/tasks"

```cs
Get("/tasks", async(TaskDb database) => await database results)
```

#### Get Task

* This endpoint returns a specific task
* Will be done asynchronously
* URI - "/tasks/id"

```cs
Get("/tasks/id", async(TaskDb database, int id) =>
{
  Task task = await database Tasks find (id)

  if task is null return NotFound
  return task
}
```

#### Get Folders

* This endpoint returns a list of all folders in the database
* Will be done asynchronously
* URI - "/folders"

```cs
Get("/folders", async(TaskDb database) => await database results)
```

#### Get Folder

* This endpoint returns all tasks that belong to a specific folder
* URI - "/folders/folderId"

```cs
Get("/folders/folderId", async(TaskDb database, int folderId) =>
{
  await database results where Task.FolderId == folderId
}
```

#### Post Task

* This endpoint creates a task object and adds it to the database
* URI - "/tasks"

```cs
Post("/tasks", async(TaskDb database, Task task) => 
{
  database add task
  await save changes
  return created results
}
```

#### Post Folder

* This endpoint creates a new folder
* URI - "/folders"

```cs
Post("/folders", async(TaskDb database, Folder folder) => 
{
  database add folder
  await save changes
  return created results
}
```

#### Put Task

* This endpoint updates a specific task in the database
* URI - "/tasks/id"

```cs
Put("/tasks/id", async(TaskDb database, Task newTask, int id) => 
{
  Task task = await database Task find (id)
  if task is null return NotFound
  task title = newTask title
  task description = newTask description
  task dueDate = newTask dueDate
  task FolderId = newTask FolderId

  await save changes
  return NoContent
}
```

#### Put Folder

* This endpoint updates a specific folder in the database
* URI - "/folders/folderid"

```cs
Put("/folders/folderId", async(TaskDb database, Folder newFolder, int folderId) =>
{
  Folder folder = await database Folder find (folderId)
  if folder is null return NotFound

  folder title = newFolder title

  await save changes
  return NoContent
}
```

#### Delete Task

* This endpoint deletes a specific task from the database
* URI - "/tasks/id"

```cs
Delete("/tasks/id", async(TaskDb database, int id) =>
{
  Task task = await database Task find (id)
  if task is null return NotFound
  
  database remove task
  await save changes

  return NoContent
}
```

#### Delete Folder

* This endpoint deletes a specific folder from the database and all the tasks in that folder
* URI - "/folders/folderId"

```cs
Delete("/folders/folderId", async(Taskdb database, int folderId) =>
{
  Folder folder = await database Folder find (folderId)
  if folder is null return NotFound

  database remove folder
  await save changes

 return NoContent
}
```

## Implementation

### Models

* All models were implemented and migrated well

### Endpoints

* No issues while implementing endpoints

## Testing

* Running the project
  * When running project, errors regarding not being able to convert an int to either a `TaskObj` or `Folder`
  * Problem:
    * In both of the delete endpoints, I attempted to remove objects from their database by passing thier `id` in the
      `Remove` method
```cs
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
```
  * Fix:
    * I replaced the id with the objects found using the `FindAsync` methods
```cs
app.MapDelete("/tasks/{id}", async (TaskDb db, int id) =>
{
  TaskObj task = await db.Tasks.FindAsync(id);
  if (task is null) return Results.NotFound();

  db.Tasks.Remove(task);
  await db.SaveChangesAsync();
  return Results.NoContent();
});

app.MapDelete("/folders/{folderId}", async(TaskDb db, int folderId) =>
{
  Folder folder = await db.Folders.FindAsync(folderId);
  if (folder is null) return Results.NotFound();

  db.Folders.Remove(folder);
  await db.SaveChangesAsync();
  return Results.NoContent();
});
```
* Creating a task (no folder)
  * Creating a task with no folder works as expected
* Updating a task (no folder)
  * Updating a task with no folder works as expected
* Deleting a task (no folder)
  * Deleting a task with no folder works as expected
* Creating a folder
  * Creating a folder works as expected
* Updating a folder
  * Updating a folder works as expected
* Deleting a folder (with no tasks)
  * Deleting a folder with no tasks works as expected
* Creating a task (with folder)
  * Creating a task with a folder does not work as expected
  * Error:
    * SQLite Error 19
    * Seems to be an issue with the foreign keys
    * Fix
      * I'll try to alter the endpoint by adding a parameter for a folder id.
        That way I can find a folder if an id is provided, and set the actual
        folder object as to the task object
  * Error
    * Causing an infinite loop between the `Tasks` and `Folders` tables
    * Fix
      * I updated the `TaskObj` model so that the `Folder` key is not included in the Json
* Updating a task (with folder)
  * Updating a task with folder works as expected
* Deleting a task (with folder)
  * Deleting a task with folder works as expected
* Deleting a folder (with tasks)
  * Error
    * SQLite error 19
    * Foreign key error
    * Fix
      
