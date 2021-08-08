## Task

- Create a registration / login form, where the user can enter an email (as login), name and password.
- Registration form should have validation on password - at least 6 symbols, should contain at least 1 uppercase letter and a special sign (i.e. !@#$%^&*()_).
- After sign up - send a confirmation email “Welcome, <username>”.
- After login - save session (i.e. refreshing browser or opening same site in new tab should keep you signed in). Show a welcome message “Hello, <username>”.
- You can use MSSQL/MySQL or SQLite for database. Please, try to keep code readable, comments will be welcome. Using REST standards for API is preferrable. It is OK to use any third-party libraries if needed.
- Don’t spend too much time for edge-cases (i.e. error scenarios), we can discuss them separately if needed.

## Additional requirements

- Forgot password functionality. User should be able to enter email and receive a password reset link. The link should be valid for 60 minutes. Only the last reset link should be working (if resetting password multiple times)