                                                       PetShop API

                This repository contains the backend API for managing employees and pets in a pet shop.

                                                      Introduction

PetShop API is a service designed to manage employees and pets within a pet shop environment. It provides endpoints for creating, retrieving, updating, and deleting both employees and pets.

Technologies
ASP.NET Core 8
Entity Framework Core
PostgreSQL
JWT Authentication
Swagger UI for API documentation

API Endpoints

Employee Controller  

    -GET /api/employee/{employeeID}: Retrieve an employee by ID.
    
    -GET /api/employee: Retrieve all employees.
    
    -POST /api/employee: Add a new employee.
    
    -PUT /api/employee: Update an existing employee.
    
    -DELETE /api/employee: Delete an employee.
    

Pet Controller

    -GET /api/pet/{petID}: Retrieve a pet by ID.
    
    -GET /api/pet: Retrieve all pets.
    
    -POST /api/pet: Add a new pet.
    
    -PUT /api/pet: Update an existing pet.
    
    -DELETE /api/pet: Delete a pet.
    

User Controller

    -POST /api/user/register: Register a new user.
    
    -POST /api/user/login: Login and receive a JWT token.
    
    -Authentication
    
        -This API uses JWT (JSON Web Token) for authentication. Include the token in the Authorization header prefixed with "Bearer" to access protected routes.

Database

    -The API uses PostgreSQL database. Configure your database connection string in `appsettings.json`.
