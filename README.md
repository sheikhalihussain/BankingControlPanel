1. Project Setup
•	Created a New ASP.NET Core Web API Project: Used the latest version of .NET Core.
•	Authentication & Authorization:
o	Implemented JWT Bearer Authentication.
o	Use ASP.NET Core custom Identity to handle user registration and role management (Admin, User).
o	Configure role-based authorization.

2. Data Access Layer
•	Entity Framework Core: Used EF Core with Code First Migrations for database handling.
•	Repositories: Implemented repository pattern to manage CRUD operations.
3. Service Layer
•	Business Logic: Created services to handle business rules, including client management and search history persistence.
•	Caching: Used an in-memory cache to store and retrieve the last 3 search parameters.
4. Controllers
•	Account Controller:
o	Endpoints for user registration and login.
•	Client Controller:
o	CRUD operations with pagination, filtering, and sorting for Admins.
o	Used [Authorize(Roles = "Admin")] to secure endpoints.
5. Error Handling
. Return appropriate HTTP status codes and error messages.
6. Swagger
•	Implemented Swagger for Endpoints.
7. Source Control
•	Use Git for version control Uploaded on GitHub.
•	Added Commits with descriptive messages.
Tools and Libraries
•	JWT Authentication: Microsoft.AspNetCore.Authentication.JwtBearer
•	Entity Framework Core: Microsoft.EntityFrameworkCore
•	Validation: FluentValidation
•	Cache: Microsoft.Extensions.Caching.Memory
Use http://localhost:5001 in browser to start the project.
