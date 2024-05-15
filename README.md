# Client Connect API
### Customer Connect CRM System

## Project Overview
Client Connect is a Customer Relationship Management (CRM) system designed to manage and analyze customer interactions and data throughout the customer lifecycle. The goal is to improve business relationships with customers, assist in customer retention, and drive sales growth.

## Database Schema
The database for this system includes the following tables:

### Customers
- `CustomerId`: Unique identifier for each customer.
- `FirstName`: Customer's first name.
- `LastName`: Customer's last name.
- `Email`: Customer's email.
- `PhoneNumber`: Customer's phone number.

### Interactions
- `InteractionId`: Unique identifier for each interaction.
- `CustomerId`: Reference to the customer involved in the interaction.
- `InteractionType`: The type of interaction (e.g., email, phone call, meeting).
- `InteractionDate`: The date of the interaction.
- `EmployeeId`: Reference to the employee who had the interaction.
- `Notes`: Any notes about the interaction.
- `EmployeeComment`: Any comments that the employee has about the interaction.

### Sales
- `SaleId`: Unique identifier for each sale.
- `CustomerId`: Reference to the customer who made the purchase.
- `ProductId`: Reference to the product that was sold.
- `SaleDate`: The date of the sale.
- `SaleAmount`: The amount of the sale.

### Products
- `ProductId`: Unique identifier for each product.
- `ProductName`: Name of the product.
- `ProductDescription`: Description of the product.
- `ProductPrice`: Price of the product.

### Employees
- `EmployeeId`: Unique identifier for each employee.
- `FirstName`: Employee's first name.
- `LastName`: Employee's last name.
- `Email`: Employee's email.
- `PhoneNumber`: Employee's phone number.

### Client Feedback
- `FeedbackId`: Unique identifier for each feedback.
- `CustomerId`: Reference to the customer who provided the feedback.
- `Feedback`: The feedback text.
- `DateProvided`: The date when the feedback was provided.

## Packages and Tools Used

This project uses a number of packages and tools:

- **MySQL Database**: Used for data persistence. MySQL is a popular open-source relational database management system.

- **AutoMapper**: A simple little library built to solve a deceptively complex problem - getting rid of code that mapped one object to another. This type of code is rather boring and tedious to write, so why not invent a tool to do it for us?

- **Authentication JWT (JSON Web Tokens)**: Used for securing the API. JSON Web Token (JWT) is an open standard (RFC 7519) that defines a compact and self-contained way for securely transmitting information between parties as a JSON object.

- **Identity Framework Core**: Used for user management. ASP.NET Core Identity is a membership system that adds login functionality to ASP.NET Core apps. It includes many features out of the box, such as user registration, two-factor authentication, and password reset.

- **Swagger**: Used for API documentation. Swagger is an Interface Description Language for describing RESTful APIs expressed using JSON. Swagger is used together with a set of open-source software tools to design, build, document, and use RESTful web services.

- **Postman**: Used for API testing. Postman is a popular API client that makes it easy for developers to create, share, test and document APIs.

Remember to install these packages and tools before you start developing your project.

## Machine Learning Model
(TODO) The idea is that the CRM system uses various machine learning models for customer segmentation and sales forecasting. The idea is to integrate a pipeline in the service layer to allow the use of python scripts, or use python.NET. 

## Getting Started
To get started with this project, clone the repository and install the necessary dependencies.

## Contributing
We welcome contributions! Please see our contributing guidelines for details.

## License
This project is licensed under the Apache 2.0 License.
