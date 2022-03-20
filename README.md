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

---

`set ASPNETCORE_ENVIRONMENT="Development"

if you have docker installed the database can be contianerized by running the following command:
`docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=***" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest`
to verify that the container is running:
`docker ps`

### TODO List:

- List, View Details of data items.
- Should be able to filter the data.
- Make sure site is responsive.
- Add sass/less as a pre-compiler for styling -> can use gulp.

#### Bonus List:

- Allow filters on additional fields.
- Add tests.
- Docerize db
- Css animations.
