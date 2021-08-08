## Assignment for ST VUVC DevOps Engineer Candidate.

Complete all task points as much as possible. As a result of the work is a docker container with the solution of the given work task in it. To solve the tasks, the image of the docker container, all the necessary tools, solution methods and the choice of the required applications are the free choice of each candidate. After completing the task, send a link with the option to download a container to test the task.

## Goal

- Create a new docker container;
- Insert the database tables provided by METER_A.SQL and DATA_E.SQL MySQL;
- Install in the container all the necessary tools and databases for data acquisition with SQL queries;
- Create appropriate SQL scripts;
- Process the obtained data and visualize the result on the container web page.

## Content of databases

- METER_A.SQL - list of electricity meters containing columns:
- ID - el. meter ID number;
- MSNO - el. meter serial number;
- STATUS - el. meter status (0 - inactive, 3 - active);
- TML_ID meter data hub ID.
- DATA_E.SQL - el. energy profile table (data table) containing columns:
- DATA_TIME - date and time of the energy profile (each day must contain 24 hours from 00:00 to 23:00);
- METER_ID meter ID number;
- SAVEDB_TIME. energy profile storage time in the database;
- KWH_IMPORT - el. energy profile A + record;
- KWH_EXPORT - el. energy profile A-record;
- MDM_Status - marker for transferring the energy profile to the Meter Data Management system or MDM (1 - passed, NULL - not passed).
    
## Task

- Select meter serial numbers (MSNO) el. meters that are active but not connected to a data concentrator;
- Select individual meter ID numbers and e-mails. the number of energy profile hours as of 16.04;
- Create table - PROFILES (meter ID number, number of energy profile hours). Select individual meter ID numbers and the number of energy profile hours for the date 16.04 that have an energy profile for all 24 hours and insert in a new table PROFILES (meter ID number, number of energy profile hours);
- Create table - PROFILES_4_DAYS (counter ID number). Select individual meter ID numbers that have an energy profile for all 24 hours on all days from 16.04-19.04 (inclusive) and insert in a new table PROFILES_4_DAYS (meter ID number);
- Create table - PROFILES_4_DAYS_MSNO (meter serial number, Status). Select meter serial numbers (MSNO) that have an energy profile for all 24 hours on all days from April 16 to April 19 (inclusive) and the meter status is active. Insert PROFILS_4_DAYS_MSNO (counter serial number, Status) in a new table.

Note: full el. the number of hours of energy profile per meter per day is 24 records.
