## Goal

To create a small WEB application based on:

- JS framework (vēlams Typescript Vue)
- CSS framework Bootstrap


## Requirements

- To display user data and their task list using state management, the data must be available without calling the API again.
- WEB application consists of 2 pages:
    - Users and their basic information - `hostname /`
         - User data - API https://jsonplaceholder.typicode.com/users
    - User to-do list - `hostname / user /: id / todos`
         - `: id` is the user ID
         - User Tasks - API https://jsonplaceholder.typicode.com/todos
    - Users and their basic information page layout `hostname /`
         - All users are displayed where each user has their own card with their data:
             - name
             - email
             - city, street, suite, zipcode
         - Clicking on one of the tabs opens the user task sarakshostname / user /: id / todosts
    - User task list page layout `hostname / user /: id / todos`
         - The list of tasks is displayed in tabular form
             - id
             - title
             - completed
- The WEB application must be responsive. 
- The design of the site will not be evaluated.
