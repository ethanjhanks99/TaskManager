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
* What I already know how to do
  * Create endpoints in .NET
* What I don't know how to do
  * Instantiate and use models in .NET
  * Implement authentication in .NET
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

