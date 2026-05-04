# Agent Instructions — ASP.NET Core Web API

This is the BACKEND project only.
The Angular frontend is in a completely separate project — DO NOT create frontend code here.

Architecture: Clean Architecture (4 layers: Domain, Application, Infrastructure, API)
ORM: Entity Framework Core (Code First)
Pattern: CQRS with Repository pattern

Always follow .github/copilot-instructions.md.
Never put business logic in Controllers.
Never use EF Core DbContext in Application layer — use repository interfaces.
Always ask before running any terminal commands (dotnet ef migrations, dotnet build etc.).