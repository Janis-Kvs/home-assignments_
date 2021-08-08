## Giraffe360 - React developer task

In this small task you will create an onboarding application, that is rendered through backend
server, collects the relevant information from the user and submits this data back to server
through the api.


### The task

You need to create an onboarding application which collects the personal information of the user
and submits it to backend. The build of this application will be rendered as a template from the
backend server. The server will inject the necessary data into the application by replacing a
placeholder in the index.html with a json string, and the resulting index.html will be served to
browser. The placeholder will be replaced as follows:

``` {{ initial_data }} ```

will be replaced with

``` '{"email": "john.doe@example.com", "company": "Example Inc.","company_id":"8092afee-a7eb-11eb-bcbc-0242ac130002"}' ```

1. The application should be written using javascript or typescript and React.
2. You are not allowed to use external libraries such as Material UI, Ant and the like, but you
can use semantic css, tailwindcss or styled components (whichever you prefer).
3. You can use icons from wherever you want (including Material, Ant etc.).


### The onboarding application should collect the following information about the user:
1. First name
2. Last name
3. Password
4. Whether to receive notifications on their project completions.
5. Whether to receive latest updates about our services and offers.

The data collected should be sent as a json request to the backend server.


### Notes:

1. You can pull the mocked version of backend from ```https://github.com/briskajanis1/onboarding-mock-backend```, and follow the instructions in readme.md to start it on your local system.
This will serve you as a mock to develop and test your api request. If you have any questions
or problems with starting backend server locally, please contact ```janis.briska@dev.giraffe360.com```.
2. A simple solution with ```{{ initial_data }}``` placeholder will be accepted. When testing we
will replace this placeholder manually with the example data. However, extra credit will be
given if you develop a generic solution, which will have ```{{ initial_data }}``` placeholder
when ```NODE_ENV=production``` and example data when ```NODE_ENV=development``` .
3. You don't need to implement the server-side rendering. Just make sure the placeholder is in
place where the data should be put in. Since we do not provide you with means to test this,
we will accept if the placeholder replacement part has minor errors. 



