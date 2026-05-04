---
mode: agent
---
Scaffold a complete Clean Architecture feature for: ${input:featureName}

Create:
1. Domain/Entities/${input:featureName}.cs
2. Domain/Interfaces/I${input:featureName}Repository.cs
3. Application/DTOs/${input:featureName}Request.cs + ${input:featureName}Response.cs (records)
4. Application/Commands/Create${input:featureName}Command.cs + Handler
5. Application/Queries/GetAll${input:featureName}sQuery.cs + Handler
6. Infrastructure/Repositories/${input:featureName}Repository.cs
7. Infrastructure/Configurations/${input:featureName}Configuration.cs (EF Fluent API)
8. API/Controllers/${input:featureName}sController.cs (thin — calls handlers only)

Follow all rules in .github/copilot-instructions.md strictly.