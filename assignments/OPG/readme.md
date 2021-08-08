## Preparation

To create test database run homework.sql DUMP file.

# Task 1

There are three tables - Jobs, Jobsteps, Projects.
In column "points", under Jobs table, there are given hour amount in which task should be completed. 

According to the data in table Projects create a new column "End Date" and calculate the date on which the project will end, keep in mind that:
- One person works 8 hours a day.
- For each project humanpower (how many people work on the project) is indicated (table Projects).
- Note that work does not take place on weekends.
- The project start date is indicated in the project table, in the start_date column.
- Note that work is not done during weekends.
- Project start date is indicated in the start_date column (table Projects).


# Task 2

In the table Jobsteps change the coefficients for the project:
- LAYOUT 0.02 -> 0.03
- STEEL 0.17 -> 0.15
- FIRSTSIDE 0.21 -> 0.25
- SECONDSIDE 0.35 -> 0.20/0.15 (Add a new row and name Jobtype to SECONDSIDE2)

In the table Jobs, recalculate the "Points" column with the conditions:
- project = SCHOOL1
- status = 1
- date> 2020-03-01
- add rows with the new jobtype (SECONDSIDE2) to the required project.