# TechnicalTest.API

A RESTful Web API built with ASP.NET Core (.NET 10) for managing Companies and Claims data.

## Index

- [About](#beginner-about)
- [Usage](#zap-usage)
  - [Installation](#electric_plug-installation)
  - [Commands](#package-commands)
- [Development](#wrench-development)
  - [Pre-Requisites](#notebook-pre-requisites)
  - [Development Environment](#nut_and_bolt-development-environment)
  - [File Structure](#file_folder-file-structure)
  - [Build](#hammer-build)
  - [Deployment](#rocket-deployment)

## About

TechnicalTest.API is an ASP.NET Core Web API that exposes endpoints for querying and managing **Companies** and **Claims**. It uses in-memory mock data and follows a service layer pattern with dependency injection. The project includes a companion test project using MSTest and Moq.

**Key features:**
- Get a company by ID with active policy status derived from associated claims
- Get all companies
- Get claims by company ID or by UCR (Unique Claim Reference)
- Update a claim
- Swagger UI available in development for easy endpoint exploration

## Usage

Once running, navigate to the Swagger UI to explore and execute all available endpoints:

```
https://localhost:7195/swagger
```

### :electric_plug: Installation

1. Clone the repository:
```
$ git clone <repository-url>
```

2. Restore dependencies:
```
$ dotnet restore
```

### :package: Commands

Start the API:
```
$ dotnet run --project TechnicalTest.API
```

Run the tests:
```
$ dotnet test TechnicalTest.Test
```

## :wrench: Development

### :notebook: Pre-Requisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- An IDE such as [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) with the C# extension

### :nut_and_bolt: Development Environment

1. Clone the repository and open the solution folder:
```
$ git clone <repository-url>
$ cd TechnicalTest
```

2. Restore NuGet packages:
```
$ dotnet restore
```

3. Run the API in development mode (Swagger UI will be available):
```
$ dotnet run --project TechnicalTest.API
```

### File Structure

```
.
├── TechnicalTest.API
│   ├── Controllers
│   │   ├── CompanyController.cs
│   │   └── ClaimController.cs
│   ├── Models
│   │   ├── Company.cs
│   │   ├── Claim.cs
│   │   ├── ClaimType.cs
│   │   └── DTOs
│   │       ├── CompanyDTO.cs
│   │       └── ClaimDTO.cs
│   ├── Services
│   │   ├── ICompanyService.cs
│   │   ├── CompanyService.cs
│   │   ├── IClaimService.cs
│   │   └── ClaimService.cs
│   ├── MockData.cs
│   └── Program.cs
└── TechnicalTest.Test
    ├── CompanyServiceTests.cs
    └── CompanyControllerTests.cs
```

| No | File | Details |
|----|------|---------|
| 1  | Program.cs | App entry point, DI registration, middleware pipeline |
| 2  | MockData.cs | In-memory data source for companies and claims |
| 3  | CompanyService.cs | Business logic for company operations |
| 4  | ClaimService.cs | Business logic for claim operations |
| 5  | CompanyController.cs | REST endpoints for `/api/company` |
| 6  | ClaimController.cs | REST endpoints for `/api/claim` |

### Build

```
$ dotnet build
```

## FAQ

**Q: Why is there no database?**
A: The project uses in-memory mock data (`MockData.cs`) as a stand-in for a real data source.

**Q: How do I add a real database?**
A: Install Entity Framework Core, add a `DbContext`, and replace `MockData` calls in the services with context queries.

## Comments
I have added test for the companyService but to not overenginerring the data used in the stest is the same as the one from the services. 
LIn a real project I would add loggin and pagination for the endpoint and services. Security for the api
