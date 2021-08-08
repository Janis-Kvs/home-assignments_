## Goal

To create a program for CV data storage.

## Requirements for Frontend

- Create at least three views:
    - List of entered CVs (delete, edit, add CV)
    - Single CV editing view (add, edit data)
    - Single CV preview view (display of CV data as it should be printed out)
- The CV consists of three parts
    - Basic data
    - Education
    - Work experience
- You can chose visual design and technologies 

## Requirements for Backend

- It is necessary to link the application with its own database. 
- Use PHP
- Tables in DB with
    - CV basic data (name, surname, phone, e-mail)
    - Educational institutions (name, faculty, field of study, level of education, status - completed, discontinued, studying, time spent in studies, etc.)
    - Jobs (title, position held, workload, length of service - time spent at work, etc.)
    - Skills or achievements used in the workplace (type of description - main job, achievement, additional skills, etc.)
    - Addresses (country, index, city, street, number, etc.)
- The basic data are related to educational institutions and jobs
- Job places are ralated to the skills and achievements used in the workplace
- Addresses are related to place of residence, work addresses, educational institution addresses
- You can add additional data and tables, such as other skills, language skills, interests.

### Question sent to company and answer received
<strong>Q: </strong>Are there any additional recommendations for the tools used to complete the task ("packages", "frameworks"),<br>
or is the solution expected to be "pure PHP" and "VanillaJS"?<br>
<strong>A: </strong>It is recommended to use the Yii2 framework, but other PHP frameworks can be chosen. The solution<br>
must be in a state where it can be "used". The bonus would be knowledge of Git, Docker, and Composer demonstrated.