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

#### `TasksDb.cs`

* This is the database context for the `Task` model
* This db context will use the `Task` model as the DbSet

```cs
using Task.Models
using EntityFrameworkCore

namespace Task.Data

public class TaskDb : DbContext
{
  public DbSet<Task> Tasks { get and set }
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

#### `FolderDb.cs`

* This is the database context for the `Folder` model
* When the database is created, a default folder will be created

```cs
using Task.Models
using EntityFrameworkCore

namespace Task

public class FolderDb : DbContext
{
  public DbSet<Folder> Folders { get and set}
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelbuilder.Entity<Folder>().HasData(
      new Folder{Id = 1, Title = "Misc."};
  }
}
```


