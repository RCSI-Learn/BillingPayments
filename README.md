# Billing Test

## BasicBilling.API
- The api has the basic functionallity specified in the story description and NEXION.postman_collection.json file.
- The API verify if the database has registers, if not then fill the Data Base with test data, period **202001** and **202002** for the 5 clients with the **ID described in Assumptions of the Front End Application file**.
- The Bill has 2 states Pending & Paid.
- The request returns 200 in every route, except the paid request when the requested Bill has not exist, then return 404 Not Found, but not for an error of the application.
- Returns the data in Json Format.
- The project was developed with .NET Core 3.1 and Visual Studio Code for the validation of `dotnet new webapi -n BasicBilling.API` 
- The DataBase used is SQLite.
-  C#8 is used.
- The migrations is added in the project.
- Used Dependency Injection for the DataContext.
- For test, NEXION.postman_collection.json file was used.

### Complement
- The Logic is in the same project.
especification, the Id used is the described on the pdf file.
-  I Try to use Unit Test, but can't be added to the project, the project doesn't compile, attempts with nuget packages and dotnet cli.


## basic_billing_frontend
- The Front application has the basic funtionallity described in the story section of Nexion - TechTest - Frontend - App for Billing Payments v1.pdf file.
- The application accomplishes the three requirements:
	- Ability to perform a bill payment based on Client ID, Type of service and Month-Year (YYYYMM).
	- Ability to retrieve pending bills per Client
	- Ability to retrieve the history of payments
- The application works with the Backend Services, runing on the url and port specified in the pdf files.
- The API verify if the database has registers, if not then fill the Data Base with test data, period **202001** and **202002** for the 5 clients described in Assumptions.
- The Bill has 2 states Pending & Paid.
- All calls should return 200 code when a request is successful
- The request returns 200 in every route, except the paid request when the requested Bill has not exist, then return 404 Not Found, but not for an error of the application.
- The applicacion use React.
- The application use React Hooks and Typescript.
- The application dont use JQuery.
- The application doesnt have test.

## Explanation
- After download and install the modules and dependencies the application runs with **npm start**, for more security all the files was inluded.
- The application has a main table where the bills are displayed.
- In the Top are 3 buttons for bill creation and searching actions.
- If any bill in the table has the **PENDING** state, a button for payment will be displayed in the right.


# Last Update
## BasicBilling.API
Added ILogic interface in Models folder.
Added ILogic and Logic to the dependencies collection in Startup.cs.
Added ClientBillDto.cs for the PaymentHistory result.
Modification in the Logic class to return IEnumerable instead of List.
Modificacion en el metodo CreateBilling, ya no se usa ForEachAsync.
Modification in the GetPaymentHistory method, an IEnumerable of type ClientBillDto is returned.
Modification in BillingController to receive and return IEnumerable.
Modification, in the controller constructor the ILogic dependency is injected which was registered in the dependency collection in Startup.cs.
Added the GetAllClients method to help with the operation of the frontend application.

## basic_billing_frontend
Reorganization of folders and files that make up the project specially on App.tsx file.
Modified appearance application.
Removed old libraries for style, styles are specified on elements and components.
Removed use of Axios
Added Hooks and Redux Toolkit Query.
Added Models folder for Bill, Client, NewBill and ClientBillDto interfaces.
Added requests for all clients, to be able to consult pending invoices.
Explanation of components folder:
- Components -> MainContainer.tsx and MainContainer.css: Contains all other components.
- basicElements -> Contains all basic HTML elements in a react component.
	- Select.tsx -> Select HTML element, which receives a data dictionary to assemble the options and returns the value selected by the user in a function.
- forms -> Contains all react componentes that are a form.
	- CreateBillForm.tsx -> Form for creating invoices for all clients by period and category.
- Lists -> Contains all react componentes that are a list or list item.
	- ClientBillsPendingList.tsx -> shows the list of pending invoices of a client and contains the button which allows you to pay the invoice.
	- ClientList.tsx -> Gets the list of clients and generates a ClientListIem for each client.
	- ClientListIem.tsx -> Displays the customer's name and calls the ClientBillsPendingList component to check their pending invoices.
	- PaymentHistoryList.tsx -> Shows paid invoices filtered by category.

## Notes
The project was edited and corrected with visual studio code.
To run the project you must go to the BasicBilling.API path and execute the dotnet build and dotnet run commands.
To run the front project you must go to the basic_billing_frontend path and execute the npm install and npm start commands.