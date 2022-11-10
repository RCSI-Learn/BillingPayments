# Billing Test

## BasicBilling.API
- The api has the basic functionallity specified in the story description and NEXION.postman_collection.json file.
- The API verify if the database has registers, if not then fill the Data Base with test data, period **202211** and **202212** for the 5 clients described in Assumptions, the **periods in the NEXION.postman_collection.json are different**.
- The Bill has 2 states Pending & Paid.
- The request returns 200 in every route, except the paid request when the requested Bill has not exist, then return 404 Not Found.
- Returns the data in Json Format.
- The project was developed with .NET Core 3.1 and Visual Studio Code for the validation of `dotnet new webapi -n BasicBilling.API` 
- The DataBase used is SQLite.
-  C#8 is used.
- The migrations is added in the project.
- Used Dependency Injection for the DataContext.
- For test the NEXION.postman_collection.json file was used.

### Complement
- The Logic is in the same project.
- The Id of clients are different in the postman file and in the pdf especification, the Id used is the described on the pdf file.
-  I Try to use Unit Test, but can't be added to the project, the project doesn't compile, attempts with nuget packages and dotnet cli.