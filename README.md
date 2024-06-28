# backmvp

This repository contains the backend MVP (Minimum Viable Product) for NekkuDB.

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)

## Features

- API endpoints for user management
- Data models for the application
- Repository pattern for data access
- Configuration and setup files

## Installation

To get started with the project, follow these steps:

1. **Clone the repository**
   ```sh
   git clone https://github.com/NekkuDB/backmvp.git
   cd backmvp
   ```

2. **Restore dependencies**
   ```sh
   dotnet restore
   ```

3. **Build the project**
   ```sh
   dotnet build
   ```

4. **Run the application**
   ```sh
   dotnet run
   ```

## Usage

The backend MVP exposes several API endpoints for managing users. You can interact with these endpoints using tools like Postman or curl. 

Example:
```sh
curl -X GET http://localhost:5000/api/users
```

## Project Structure

- **Controllers/**: Contains the API controllers.
- **Models/**: Defines the data models.
- **Repositories/**: Contains repository classes for data access.
- **Properties/**: Project configuration files.
- **Program.cs**: The main entry point for the application.
- **Startup.cs**: Configures the application services and middleware.
- **appsettings.json**: Configuration file for application settings.
