# Demo Codex

This repository contains two sample ASP.NET Web API projects and a React frontend for managing users.

See [docs/architecture.md](docs/architecture.md) for an overview of the application architecture.

## Prerequisites
- .NET 6 SDK
- Node.js with npm
- MySQL Server (update the connection string in `appsettings.json` if needed)

## Running the APIs

Navigate to `UserManagementApi` or `UserManagementApi_EntityFrmwk` and run:

```bash
dotnet run
```

## Running the Frontend

```bash
cd frontend
npm install
npm start
```

The frontend expects an environment variable `REACT_APP_API_URL` pointing to the API base URL. By default it falls back to `http://localhost:5213`.

## Tests

Run React unit tests:

```bash
npm test -- --watchAll=false
```

There are currently no automated tests for the API projects.
