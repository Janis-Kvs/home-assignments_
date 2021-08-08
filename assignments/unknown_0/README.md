Imagine you work for a company that develops a system for a small business. Previously, your system used a manual method of making payments and receiving data from the bank.

The product owner found out that the main banks in latvia have developed an open api, which gave your company the opportunity to improve the product. The business prepared the requirements and sent it to your team.

Your manager decided not to rush and build the integration gradually, starting with SEB. Your Team Lead added that the initial design should take into account the possibility of integration with many banks. As a result, the team decided that in the end the system would be able to request data from different banks and bring the data to a common conclusion.

## Task

- write an integration service that returns an account-list with SEB openapi (https://developer.baltics.sebgroup.com/), and also takes into account that in the future it will be necessary to integrate other banks
- bring the data to a common data model
- write a console application that calls the service and displays data.

## Requirements 
- Use .NET Core 3.
