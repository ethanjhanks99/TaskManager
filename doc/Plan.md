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

