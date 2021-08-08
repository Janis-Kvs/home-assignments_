# Web Developer Test

The purpose of this test is to evaluate the knowledge of the candidate in various areas that are
related to the daily work of a Web Developer at Magebit. Please try to use the latest technologies,
and be as accurate as possible with the formatting.

## Rules

1. As the tasks listed match with the job responsibilities you would have to fulfil at work on a daily
basis, we encourage you to complete the test by yourself without asking anyone for help.
2. As we are willing to test your knowledge, please avoid using PHP frameworks or Bootstrap as it will
be harder to determine your skills in PHP, HTML, CSS, however, you are more than welcome to use
CSS preprocessors, Vue.js, React, Angular or other similar technologies.
3. In each task, you will find "Requirements"that list points mandatory for completion, and
"Advantages"that are not mandatory but can be completed by candidates who can and want to get
some extra points.
4. ReadMe file has to be in place with instructions on how to run the project locally.
5. Once the test is completed, please upload the results to GitHub and share the link with us.

## Task 1 - HTML / CSS

Create an HTML/CSS page based on the design provided below.
In this task, you must show your knowledge of HTML standards and proper structure. We will also test your
skills on writing rendering efficient CSS.

### Requirements

- The page is as pixel-perfect as possible. You can use this Chrome extension to test it.
- Bootstrap or similar frameworks are not used.
- The page is responsive for all devices.
- All URLs on-page is “#”. They do not lead anywhere.
- The form submission functionality is not part of Task 1.
- Social icons have hover effects as per style guides.
- Hover effects are present on the site as per style guides.

### Advantages

- A font with custom icons is used instead of separate icon files.
- LESS, SASS or any other CSS preprocessor is used.

### Design

- [Design link on Figma](https://www.figma.com/file/p4jxR7jTYFqSaVewJTsHFj/Mid%2FJunior---Web-Developer-Test-%7C-Task-1?node-id=0%3A1)
- [Style guide link on Figma](https://www.figma.com/file/p4jxR7jTYFqSaVewJTsHFj/Mid%2FJunior---Web-Developer-Test-%7C-Task-1?node-id=29%3A363)

## Task 2 - JavaScript

Based on Task 1 you have to create subscription input validation.
In this task, you must show your knowledge about writing fast and memory-efficient JavaScript.

### Requirements

- There is an error message under input that shows validation messages if:
- Invalid email is added - “Please provide a valid e-mail address”
- The checkbox is not marked - “You must accept the terms and conditions”
- No email address is provided - “Email address is required”
- Provided email is ending with .co - “We are not accepting subscriptions from Colombia
emails”.
- Once validation has passed, the error disappears.
- The button is disabled if the form is not valid.
- On successful validation, a success message appears in the place of the form, as per design.

### Advantages

- You can use Vue.Js, React or similar technologies.

### Design

- [Design link on Figma](https://www.figma.com/file/p4jxR7jTYFqSaVewJTsHFj/Mid%2FJunior---Web-Developer-Test-%7C-Task-1?node-id=15%3A34)
- [Style guide link on Figma](https://www.figma.com/file/p4jxR7jTYFqSaVewJTsHFj/Mid%2FJunior---Web-Developer-Test-%7C-Task-1?node-id=29%3A363)

## Task 3 - PHP / MYSQL

Based on Tasks 1 and 2, you have to create BE functionality for an email subscription.
In this task, you must show your knowledge about PHP OOP standards, PHP best practices, and security.

### Requirements

- Data that is submitted is saved in a MySQL database.
- Adjust the functionality from previous Task so that success message appears only after form submit
instead of successful validation.
- Data is validated also in PHP, and if JavaScript is disabled it displays errors in the same place and
style as it is with JavaScript enabled (exceptions apply to React and Vue headless implementations).
- A page is created where all saved data can be seen:
- No login for this page is needed.
- No styling for this page is needed. Basic HTML table is enough.
- Sorting by name and date is added (by default it sorts data by date)
- It is possible to filter email addresses by email providers:
- Example: If under subscriptions there are 3 Gmail, 5 Yahoo and 2 Outlook email
addresses, 3 buttons should appear: Gmail, Yahoo and Outlook. Once new
subscriptions from a different provider appear, for example, HubSpot, this leads to
the automatic appearance of a new button which will allow to filter out all the email
addresses with the email provider that don't have @hubspot.com at the end.
- It is possible to search for email addresses and use filters and sorting at the same time.
- It is possible to delete email addresses.

### Advantages

- It is possible to select multiple emails using checkboxes and export them as CSV.
- Pagination is present on the list with 10 emails per page.
