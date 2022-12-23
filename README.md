# HelpDebugGov

## Getting Started

### Prerequisites

- Docker
- IDE/Platform with devcontainer support (e.g., VSCode, Github Codespaces)
- Put necessary environment variables in `.env` file (see `.env.example`)

### Overview

#### Implemented

- Dynamic Policy Based Auth
- MediatR
- FluentEmail
- FluentValidation
- Code-First Migration & Seeding
- Logging (Serilog)
- DevContainer
- Swagger with Auth
- JWT based Auth, Email Confirmation, Password Reset & Change
- AutoMapper

#### Architecture

- src/HelpDebugGov.
  - Api - Web Api
  - Domain - Domain Models
  - Application - Application Services
  - Infrastructure - Data Access Layer
  - UI - Web UI (svelte)

### Notes

#### Commands

``` bash
# Api Server
dotnet watch run --project ./src/HelpDebugGov.Api/ --launch-profile https
dotnet ef migrations add MigrationName --startup-project ./src/HelpDebugGov.Api/ --project ./src/HelpDebugGov.Infrastructure
dotnet ef database drop --startup-project ./src/HelpDebugGov.Api/ --project ./src/HelpDebugGov.Infrastructure
# UI Server
pnpm run dev --filter ./src/HelpDebugGov.UI
# Miscellaneous
## merge all *.gitignore
awk '(FNR==1){print "### << " FILENAME}1' *.gitignore > .gitignore
```

### Thanks to
- https://github.com/yanpitangui/dotnet-api-boilerplate
- https://blog.joaograssi.com/series/authorization-in-asp.net-core/
