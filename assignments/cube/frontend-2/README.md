## Goal 

To create a new Laravel project and a MySQL database.

## Requirements

- Php7.3 or later version should be used
- Use data types
- Write comments
- When the job is complete, it should be sent to the archive without the vendor and node_modules folders.


## Additional requirements

- Visual presentation is optional.

## Task 1 - To read RSS feeds in a database.

- Use TVNET news source: http://feeds.feedburner.com/tvnet/all
- Data must be obtained with PHP DOM functions: http://en.php.net/manual/en/book.dom.php
- Only messages that are not in the database should be read
- Data reading must take place on weekdays at 9:00 in the morning and on weekends also at 14:00
- The author and categories of the message must be stored in separate tables
- Names must be unique.

## Task 2 - display the 6 most recent news and the "view all news" button on the home page.
- The picture, name, date must be added to the message.

## Task 3 - by pressing the "view all messages" button, you should open the news archive section, where all messages sorted by date would be available.
- Must have a pager with 10 messages per page
- The image, title, date, author and categories must be included with the message.