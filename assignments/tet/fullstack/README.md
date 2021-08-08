## Task

Create an application that reads exchange rates from the https://www.bank.lv/vk/ecb_rss.xml RSS feed and displays it to the user.

- Need a cronjob that runs from the console. It reads entries from the RSS feed and writes them to its db.
- Create REST API for list and individual currency data return.
- On the public side, it is necessary to display these entries in a table with a pager (for example, 20 entries per page).
- Ability to open an individual currency and see the exchange rates of previous days.


## Requirements

- Use MySQL (MariaDB), Symfony or Laravel framework and Angular framework for the task.
- All code, the db part, and the readme must be supplied in github (or other version control systems that use git), where the base code (framework) commit is separated from the rest of the changes.
- The readme should describe instructions that, when read, make it clear what needs to be done sequentially to install and run the application (preferably on the Docker).
