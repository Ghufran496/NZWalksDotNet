# NZWalksDotNet

A comprehensive web application for exploring walking tracks across New Zealand regions. This project demonstrates a full-stack .NET application with a RESTful API backend and an MVC frontend.

## Project Overview

NZWalksDotNet is a web application that allows users to explore and manage walking tracks across different regions of New Zealand. The application provides features for:

- Browsing regions and walks
- Adding, updating, and deleting regions and walks
- User authentication and authorization
- Image upload and management
- Interactive UI for data management

## Technology Stack

### Backend (NZWalks.API)
- **Framework**: ASP.NET Core 7.0
- **Architecture**: RESTful API
- **Database**: SQL Server with Entity Framework Core 7.0
- **Authentication**: JWT-based authentication with ASP.NET Core Identity
- **Documentation**: Swagger/OpenAPI
- **Logging**: Serilog (console and file logging)
- **Object Mapping**: AutoMapper
- **Middleware**: Custom exception handling middleware

### Frontend (NZWalks.UI)
- **Framework**: ASP.NET Core MVC
- **HTTP Communication**: IHttpClientFactory for API consumption
- **View Engine**: Razor

## Key Features

### Region Management
- View all regions of New Zealand
- Add new regions
- Update existing region information
- Delete regions
- Region image URL support

### Walk Management
- Browse walks by region
- Add new walks with details like length, difficulty, and description
- Update walk information
- Delete walks
- Walk image URL support

### Authentication & Authorization
- Role-based access control (Reader and Writer roles)
- JWT token authentication
- Secure API endpoints

### Image Management
- Upload and store images
- Serve static files

## Project Structure

### API Project
- **Controllers**: Handle HTTP requests and responses
- **Models**: Domain models and DTOs
- **Repositories**: Data access layer with repository pattern
- **Mappings**: AutoMapper profiles
- **Middleware**: Custom exception handling
- **Data**: Entity Framework DbContext and database configuration

### UI Project
- **Controllers**: MVC controllers for handling user interactions
- **Views**: Razor views for rendering UI
- **Models**: View models and DTOs

## Database Schema

The application uses the following main entities:
- **Region**: Represents a geographical region in New Zealand
- **Walk**: Represents a walking track with details
- **Difficulty**: Represents the difficulty level of a walk (Easy, Medium, Hard)
- **Image**: Stores image information

## Getting Started

### Prerequisites
- .NET 7.0 SDK
- SQL Server
- Visual Studio 2022 or any compatible IDE

### Setup
1. Clone the repository
2. Update the connection strings in `appsettings.json` for both API and UI projects
3. Run the following commands in the Package Manager Console:
   ```
   Add-Migration "InitialMigration" -Context "NZWalksDbContext"
   Update-Database -Context "NZWalksDbContext"
   
   Add-Migration "AuthDbInitialMigration" -Context "NZWalksAuthDbContext"
   Update-Database -Context "NZWalksAuthDbContext"
   ```
4. Run both the API and UI projects

## API Endpoints

The API provides the following main endpoints:
- `GET /api/regions`: Get all regions
- `GET /api/regions/{id}`: Get a specific region
- `POST /api/regions`: Create a new region
- `PUT /api/regions/{id}`: Update a region
- `DELETE /api/regions/{id}`: Delete a region
- `GET /api/walks`: Get all walks
- `GET /api/walks/{id}`: Get a specific walk
- `POST /api/walks`: Create a new walk
- `PUT /api/walks/{id}`: Update a walk
- `DELETE /api/walks/{id}`: Delete a walk
- `POST /api/auth/login`: Authenticate a user
- `POST /api/auth/register`: Register a new user
- `POST /api/images`: Upload an image

## Security

The application implements:
- JWT-based authentication
- Role-based authorization
- Secure password handling with ASP.NET Core Identity
- HTTPS communication

## Development Patterns & Practices

- Repository pattern for data access
- DTO pattern for API communication
- Dependency Injection
- Middleware for cross-cutting concerns
- Automapper for object mapping
- Entity Framework Code-First approach
- Seeding initial data

## License

This project is open-source and available under the MIT License.
 
