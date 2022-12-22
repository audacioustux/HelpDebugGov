# HelpDebugGov

## Getting Started

### Prerequisites

- Docker
- VsCode (with remote explorer / devcontainer support)
- Put necessary environment variables in `.env` file (see `./devcontainer/.env.example`)

### Notes

#### Commands

``` bash
dotnet ef migrations add <MigrationName> --startup-project ./src/HelpDebugGov.Api/ --project ./src/HelpDebugGov.Infrastructure
dotnet ef database drop --startup-project ./src/HelpDebugGov.Api/ --project ./src/HelpDebugGov.Infrastructure
dotnet watch run --project ./src/HelpDebugGov.Api/ --launch-profile HelpDebugGov.Api
```
