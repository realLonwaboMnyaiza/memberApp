# App

## This project has been created using the following technologies:

- asp.net core and c#
- angular and typescript
- sql server and ef core code first

---

## Purpose

Display user information.

### How to run the project.

- To install project depencencies:
  `npm install | npm i`

- To update database and run migrations:
  `dotnet ef database update`

- Build and run .Net API.
  `dotnet run`

- Build, run and watch for changes to build:
  `dotnet watch run`

- Set up environment variables (win | mac):
  `set | export ASPNETCORE_ENVIRONMENT="Development"`

if you have docker installed the database can be contianerized by running the following command:
`docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=***" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest`
to verify that the container is running:
`docker ps`

### TODO List:

- details view of members.
- should be able to filter the data.
- link fe to api.

#### Bonus List:

- add front end tests.
- finish api test for get member.
- create a member details page (FE).
- backend filtering and pagination.
