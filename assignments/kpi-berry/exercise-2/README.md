## Goal

To build a simple condition builder user interface using React framework and UI
elements library of your choice (Ant - preferred, Material, Bootstrap, etc.) with accompanying
HTTP API endpoints using Python/Flask.

## Context

In our platform the main data object is a subject which has a collection of different features such
as:
### Subject
- Age (integer) - age of subject
- Gender (enum[male,female]) - gender of subject
- Language (enum[lv,en,ru]) - language preference
- Channel (enum[sms,email,call]) - communication channel preference
- Marketing communication (bool) - subject accepts marketing
- Application (list) - list of applications within brand
    - Brand (enum) - associated brand
    - Product type (enum[subscription,pay_as_you_go]) - product type
    - Date (date) - application date
    - Value (float) - product value
    - Status (enum[active,inactive]) - application status
    - Status change date (date) - status change date
- Product (list) - list of products
    - Brand (enum) - associated brand
    - Product type (enum[subscription,pay_as_you_go])
    - Start date (date) - start date
    - End date (date) - end date
    - Value (float)
    - Status (enum[active,inactive])
    - Offer
    - Brand (enum) - associated brand
    - Product type (enum[subscription,pay_as_you_go])
    - Date (date) - date of offer when it becomes active
    - Expiry date (date) - offer expiry date
    - Value (float) - value
- Account status
    - Brand (enum) - associated brand
    - Date (date) - status date
    - Status (enum[active,inactive]) - status of client
    - Available product (list) - list of available products
        - Product type (enum[subscription,pay_as_you_go])
        - Value (float)

We need an easy and intuitive way of constructing boolean conditions based on these features.

Example conditions:
- Subjects of particular age group and gender involved in a particular brand
- Subjects who had the last application 30 or more days ago
- Clients who have active product of particular type
- Clients who have an active offer for particular product type
- Clients with no active products and with at least one product
This is a real world scenario.

## Task

In the homework task you will have to design and implement a simple condition builder with a
subset of required features from the real world one.

You are given the following Subject model:

Subject
- Age (integer) - age of subject
- Gender (enum[male,female]) - gender of subject
- Language (enum[lv,en,ru]) - language preference
- Channel (enum[sms,email,call]) - communication channel preference
- Marketing communication (bool) - subject accepts marketing

Implement a condition builder in which the following conditions can be expressed:
- Subjects of particular gender
- Subjects that accept marketing communications
- Subjects that are more than 20 year old
- Subjects of particular age group and gender
- Subjects that accept marketing communications and have a particular language
preference and don’t have explicit (e.g. sms) channel as preferred communication
channel

## Steps
1) Create HTTP API endpoints using Python/Flask:
    - Retrieving enum values (gender, languages, channel) for use in UI
    - Condition submission and validation - endpoint for accepting valid condition in
    JSON format
2) Create React UI (use create-react-app or similar scaffolding)
    - Design UI to be able to construct conditions as stated above
    - Retrieve enums for the API endpoint and use them in the UI
    - Submit constructed conditions to API endpoint
## Deliverable
- Archived source code
- README.txt (within the archive) with clear steps to install requirements and launch the
app (api backend, ui)
- These can be emailed to jobs@kpiberry.com
## Assessment
- Code clarity and structure
- UI concept
- API structure
- README quality
- Any other improvements and initiative are very welcome!