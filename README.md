# University Magazine Management

This repository hosts the codebase for the University Magazine Management application. This web application is built using ASP.NET Web API with RESTful architecture for backend services and Angular for frontend development. The application's data management is powered by SQL Server.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Features
- User authentication and authorization
- Article submission and management
- Editorial workflow
- User profiles and roles
- Magazine issue creation and management
- Real-time notifications
- Search and filtering functionality
- Responsive design

## Installation

### Prerequisites
- .NET SDK
- Node.js and npm
- SQL Server

### Backend Setup
1. Clone the repository
   ```sh
   git clone https://github.com/JKisoTech/University-Magazine-Management.git
   cd University-Magazine-Management/Backend
2. Restore the .NET packages
   ```sh
   dotnet restore
3. Update the connection string in appsettings.json to point to your SQL Server instance.

4. Apply migrations and seed the database
  ```sh
  dotnet ef database update
  ```
### Frontend Setup
1. Navigate to the frontend directory
  ```sh
  cd ../angular
  ```
2. Install the dependencies
  ```sh
   npm install
  ```
3. Serve the Angular application
```sh
  ng serve
```



