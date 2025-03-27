# ECommerce Backend Project

## Project Overview
This project is a backend system for an E-Commerce application built with ASP.NET Core, Entity Framework Core, and Dapper. It includes user authentication using JWT, role-based and policy-based authorization, order and product management, and unit testing with xUnit and EF Core In-Memory provider.

## Technologies Used
- ASP.NET Core Web API 
- Entity Framework Core 
- Dapper 
- JWT for authentication
- Role-based and Policy-based Authorization
- xUnit and EF Core In-Memory for unit testing
- Swagger And Postman for API testing

## Features Implemented
### Task 1: Database Design
- Code-first models using EF Core
- Relationships: Users, Products, Orders, OrderItems
- Migrations and DB initialization
- Eager loading of related data

### Task 2: Dapper Queries
- Dapper used to fetch customer orders
- Dapper used to fetch product by ID

### Task 3: JWT Authentication
- /register and /login endpoints
- JWT issued with claims & roles
- /user/profile protected route

### Task 4: Authorization
- Role-based: Admin can add/update products
- Claims-based: /orders/all for users with CanViewOrders
- Policy-based: Refunds only for Admins with CanRefundOrders

### Task 5: Order Management
- /products: List products
- /orders/create: Place orders
- /orders/{id}: Get order by ID
- The /orders/{id} endpoint was updated to return a simplified, cleaner response using a DTO. The new output includes order details, customer name, and a list of order items with product names, quantities, and prices.

### Task 6: Unit Testing
- OrderRepository tested with xUnit
- In-memory EF database for isolation
- Tests: GetOrdersByUserId, AddOrder

## Setup Instructions

### Prerequisites
- .NET 
- SQL Server
- Visual Studio or Visual Studio Code

### Clone the Repository

git clone https://github.com/OsamaAlhejaily/MiniAmazonCloneTask.git
cd MiniAmazonCloneTask


### Configure Database
Update appsettings.json with your SQL Server connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ECommerceDb;Trusted_Connection=True;"
}


### Run Migrations

dotnet ef migrations add InitialCreate
dotnet ef database update


### Run the Application

dotnet run


### Run Unit Tests

cd ECommerceTest
dotnet test


## Testing Authenticated Endpoints

### 1. Register a User
POST /api/auth/register

{
  "name": "Admin",
  "email": "admin@example.com",
  "password": "admin123",
  "role": "Admin"
}


### 2. Login to Get Token
POST /api/auth/login

{
  "email": "admin@example.com",
  "password": "admin123"
}


### 3. Use Token in Postman
- Click "Authorization"
- Paste: The token that is generated

## Sample Test Cases
- Add/Update Product (Admin only)
- View all orders (with CanViewOrders claim)
- Refund order (Admin + CanRefundOrders claim)

## Project Structure

ECommerceBackend/
├── Controllers/
├── Models/
├── Repositories/
├── Dtos/
├── Services/
├── Data/
├── appsettings.json
└── Program.cs

ECommerceTest/
├── OrderRepositoryTests.cs
└── ECommerceTest.csproj


