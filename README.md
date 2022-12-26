# HelpDebugGov

## Getting Started

### Prerequisites

- Docker
- IDE/Platform with devcontainer support (e.g., VSCode, Github Codespaces)
- Put necessary environment variables in `.env` file (see `.env.example`)

### Overview

#### Implemented

- Dynamic Policy Based Auth
- Mediator pattern
- CRUD Operations for all entities
- Email Service
- Validation
- Code-First Migration & Seeding
- Logging
- Api Documentation
- Auth, Email Confirmation, Password Reset & Change
- Web UI

#### Used

- ASP.NET 7
- EntityFrameworkCore
- DevContainer
- FluentEmail
- FluentValidation
- MediatR
- AutoMapper
- Serilog
- Swagger
- JWT
- SvelteKit
- TailwindCSS
- Pnpm + TurboRepo

#### Architecture

- src/HelpDebugGov.
  - Api - Web Api
  - Domain - Domain Models
  - Application - Application Services
  - Infrastructure - Data Access Layer
  - UI - Web UI

### Notes

- scripts/merge-gitignore.sh - merge all *.gitignore files into one
- all sensitive data should be stored in environment variables via `.env` file
- errors should not expose sensitive data to the client
- devcontainer is used for development and highly recommended
- an account with all permissions (superuser) is created (as seed) with given credentials in `.env` (SUPERUSER_*)

#### Commands

``` bash
# Run Api Server
dotnet watch run --project ./src/HelpDebugGov.Api/ --launch-profile https
# Add new Migration
dotnet ef migrations add Init --startup-project ./src/HelpDebugGov.Api/ --project ./src/HelpDebugGov.Infrastructure
# Drop Database
dotnet ef database drop --startup-project ./src/HelpDebugGov.Api/ --project ./src/HelpDebugGov.Infrastructure

# Web UI in dev mode
pnpm run dev
```

### TODO

- [ ] Add tests
- [ ] Add Production Setup
- [ ] Complete OpenTelemetry setup
- [ ] Migrations should be included in version control, but ensure no sensitive data is included
- [ ] resolve `TODO:`s in code (find all with `$ rg "// TODO:"`)
- [ ] <https://github.com/npgsql/npgsql/issues/4592> - workaround: re-`run`

### References

- <https://learn.microsoft.com/en-us/aspnet/core/security/authorization/iauthorizationpolicyprovider?view=aspnetcore-7.0>
- <https://daisyui.com>
