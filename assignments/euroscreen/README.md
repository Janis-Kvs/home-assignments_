# Preparation

You will need to log in to https://www.office.com to complete the task.

When you create an account, you will be able to move to SharePoint Online from there.

SharePoint Online is available in test / trial mode for free

https://products.office.com/lv-lv/compare-all-microsoft-office-products?&rtc=1&activetab=tab:primaryr2

At the very bottom is a link to the one-month trial version:

https://businessstore.microsoft.com/en-us/create-account/signup?offerid=467eab54-127b-42d3-b046-3844b860bebf&dl=O365_BUSINESS_PREMIUM&ispolaris=1&ali=1&products=cfq7ttc0k5j7:0002

In addition, you will need a development environment - MS Visual Studio.

## Part 1 - Website development and data preparation

1. Create a SharePoint site "Library"
1. Create a genres classifier (SharePoint list)
     1. New fields are not required (the base field - Title will suffice)
     1. Fill in the classifier manually with the values:
         1. Action
         1. Comedy
         1. Drama
         1. U.t.t
1. Create a Books Registry (SharePoint List)
     1. Fields:
         1. Title - text
         1. Author - text
         1. Genre - lookup (from the Genre field of the classifier)
         1. Pages - Number
         1. Language - menu / choise
             1. Assemble the possible values yourself
     1. Enter several (at least 5) lines / books

## Part 2 - Data entry and selection using your own Windows application

1. Create a new WinForm application using Visual Studio. We use c # programming language.
     1. The application must be able to connect to the new SharePoint online site and read the entire book list and display it in a form (eg grid)
     1. It is desirable to provide an opportunity to select books by genre. Book selection by genre should be done by sending an appropriate request to the server (CAML or REST), not locally in the client application.
     1. A new book addition form should be created to add new rows to the book index.

You will need to use SharePoint CSOM or SharePoint REST to complete the second part

### Result

- Link to the created site (with the user and password who has access to this site)
- WinForm application