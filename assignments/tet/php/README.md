## Task

Create an application that reads exchange rates from the https://www.bank.lv/vk/ecb_rss.xml RSS feed and displays it to the user.

- Need a cronjob that runs from the console. It reads entries from the RSS feed and writes them to its db.
- We create the frontend part with the React framework by logically separating the application layers.
- On the public side it is necessary to display these records in a table with a page (for example, 20 records per page)
- Ability to open an individual currency and see the exchange rates of previous days.

## Requirments

- The task to use MySQL (MariaDB), Symfony and React frameworks must use MVC, the code must be based on OOP principles.
- If the frontends look beautiful and aesthetic, of course, we will appreciate it.
- All code, the db part, and the readme must be supplied in github (or other version control systems that use git), where the base code (framework) commit is separated from the rest of the changes.
- The readme should describe instructions that, when read, make it clear what to do in sequence to install and run the application (preferably on the Docker).
