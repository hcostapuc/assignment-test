# Assignment Project

## Project Overview

Welcome to the assignment project for the Software Engineer position at VitalScientific. This project aims to assess your skills in software development. Below are the instructions to complete the project:

## Task Description
1. **Get the Zip File**: Download the provided zip file containing the assignment project.
2. **Upload to Your Repository**: Create a new public repository on your GitHub account.
3. **Task Execution**: Perform each task described in the project documentation one by one.
4. **Commit Each Task Separately**: After completing each task, commit the changes to your repository. Please ensure to make meaningful commit messages.
5. **Completion and Submission**: Once you've completed all tasks, send the link to your GitHub repository to us for review.

## Timeframe
There is no strict timeframe for completing this assignment. You're free to work on it at your own pace. However, our estimation for completing the tasks is approximately 4 hours. Feel free to allocate this time as you see fit, whether it's completing the project in one sitting or spreading it out over several days.

## Project description
This application already contains the following features, but there might be some **bugs** that need to **fixed**:

  - [x] Allows the add ToDoLists and related items.
  - [x] Each ToDoList must have a unique title.
  - [x] Each item must have a unique title within the ToDoList.
  - [x] The title of a ToDoList and items cannot exceed 200 characters.
  - [x] Validation errors should be shown to the user.
  - [x] The ToDoList view should be refreshed after adding a new ToDoList.
  - [x] The items of a ToDoList can be marked as done.
  - [x] If no ToDoList is selected, adding items should not be possible.
  - [x] If no ToDoListItem is selected or the selected item is marked as done, the done button should be disabled.
  - [x] The ToDoListItem view should be refreshed after adding a new ToDoListItem.

## New Features
The following features need to be implemented:
- [x] **Displaying Error Messages**:
  - [x] Add a feature to display validation errors as pop-ups based on MVVM design, without using the MessageBox component.

- **Weather Forecast form**:
  - [x] Add two new entities, Country and City, with a one-to-many relationship.
  - [x] Provide seed data for countries and cities.
  - [x] Implement a form for Weather Forecast and add two dropdowns:
    - [x] The first dropdown for selecting a Country.
    - [x] The second dropdown for selecting a City, which updates based on the selected Country.
    - [x] Selecting a City triggers a mock API call (interface definition and a fake implementation required) to fetch and display the temperature of the city and display it on the form.
    - [x] Writing tests for this feature is a plus.

- [x] **Simple Caching System**:
  - [x] Develop a simple in-memory cache from scratch without using any external caching libraries, including Microsoft's. Your implementation should support basic operations such as retrieving a cached value and resetting the cache using a cache key.
  - [x] Use this cache to store and manage ToDoList data, and reset it when becomes outdated.

- [x] **Project Improvement Ideas**:
  - [x] Please provide your suggestions for improving this project at the end of this file. Consider enhancements in functionality, performance, user experience, code quality, or any other areas you deem necessary.

## Guidelines
- Make sure your GitHub repository is public so that we can review your code.
- Ensure all changes are clean, well-optimized, and maintain high code quality standards.
- Refactor the codebase where necessary and commit these changes independently.
- Write clear and concise commit messages reflecting each change.

This document provides a comprehensive guide for developers to understand and contribute effectively to the ToDoList management system. For any questions or further clarifications, please consult the project's lead developer.

We wish you the best of luck and look forward to reviewing your submission!

## Project Improvement Ideas
- **Code quality**
  - Add sonar to ensure the project complies with the code rules.
  - Segregate commands and queries for their handlers. It seems that the template was based on Jason Taylor. He said that it's easier to manipulate the commands and queries when they are together with their specific handlers because it's the same file, and you don't need to find the others even violating the single responsibility from SOLID. But I still prefer having a single archive for each one because it's more readable and easier to maintain.
  - The Api integration could be doing async requets.
  - I believe the API-related work may need to be separated into a different project. Unlike the test, the API typically returns objects and involves manipulating HTTP requests. Therefore, it would be beneficial to create additional files and organize the integration data within a separate project dedicated to WeatherForecast integration.
  - Segregate the modules weatherforecast and todolist using solution folders, depending of the scenario use even different datacontexts.
  - Implement options pattern, in order to get information from appsettings.
  - Change plural representation from S to Collection, thus being clearer and avoiding the creation of the wrong class.
  - Implement log.
  - If need to create a message box customized it using window instead screen
- **User experience**
  - Make the views more visually appealing by applying margins, paddings between the components, adding icons, modern UI using Material Design and etc. Focusing on the efficiency of usability.
- **Functionality**
  - Create funcionality to delete a todolist and todoitem.
