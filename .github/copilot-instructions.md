# ASP.NET Core Web API Project — Copilot Instructions

## Stack
- ASP.NET Core 8+ Web API
- C# 13 with nullable reference types enabled
- Entity Framework Core (Code First)
- Clean Architecture (API → Application → Domain → Infrastructure)
- No Minimal APIs — use Controllers

## Code Rules
- Always use primary constructors (C# 12+)
- Use dependency injection via constructor — never `new` a service
- Use record types for DTOs and value objects
- Use `async/await` everywhere — no blocking `.Result` or `.Wait()`
- Never use `var` when type is not obvious from right-hand side
- Nullable reference types always enabled — no `null!` suppressions
- Never expose Domain entities directly via API — always map to DTOs
- Never put business logic in Controllers — use Application layer services
- Never put SQL queries in Controllers or Application layer — use Repository pattern

## SOLID Principles
- S: Controllers only handle HTTP — no business logic
- S: Services handle ONE domain concern only
- S: Repositories handle ONE aggregate/entity only
- O: Use abstract base classes or interfaces — extend, never modify
- L: All implementations must fully honor their interface contracts
- I: One interface per consumer need — never one large interface
- D: All dependencies via constructor injection — never instantiate with `new`

## Clean Architecture Layer Rules

### Domain Layer (innermost — zero dependencies)
- Entities, Value Objects, Domain Events
- Interfaces (IRepository, IDomainService)
- No EF Core, no HTTP, no external packages

### Application Layer
- Use Cases / Service classes
- CQRS: ICommand, IQuery, ICommandHandler, IQueryHandler
- DTOs (Request/Response records)
- Interfaces it needs (IEmailService, IFileStorage etc.)
- No EF Core DbContext directly — use repository interfaces

### Infrastructure Layer
- EF Core DbContext and Migrations
- Repository implementations
- External service implementations (email, storage, etc.)
- Register everything via DI in this layer

### API Layer (outermost)
- Controllers only — thin, no logic
- Middleware, Filters, Exception Handlers
- Program.cs DI registration
- No business logic here

## Naming Conventions
- Controllers: `UsersController`, `OrdersController` (plural)
- Services: `UserService`, `OrderService`
- Repositories: `UserRepository`, `OrderRepository`
- DTOs: `CreateUserRequest`, `UserResponse`, `UpdateUserRequest`
- Interfaces: `IUserService`, `IUserRepository`
- Commands: `CreateUserCommand`, `DeleteOrderCommand`
- Queries: `GetUserByIdQuery`, `GetAllUsersQuery`
- Handlers: `CreateUserCommandHandler`, `GetUserByIdQueryHandler`

## API Design Rules
- REST conventions: GET (fetch), POST (create), PUT (full update), PATCH (partial), DELETE
- Endpoints: plural lowercase → /api/users, /api/orders
- Always return `ActionResult<T>` — never raw objects
- Use HTTP status codes correctly:
  - 200 OK → successful GET/PUT/PATCH
  - 201 Created → successful POST (with Location header)
  - 204 NoContent → successful DELETE
  - 400 BadRequest → validation failure
  - 404 NotFound → resource missing
  - 409 Conflict → duplicate resource
  - 500 → never expose raw exceptions
- Always validate with Data Annotations or FluentValidation
- Never expose stack traces or internal errors to client

## EF Core Rules
- Code First only — never scaffold from database
- Use Fluent API in EntityTypeConfiguration classes — never Data Annotations on entities
- Migrations go in Infrastructure layer
- Always use AsNoTracking() for read-only queries
- Use pagination for all list endpoints — never return unbounded lists
- Use projection (Select) to avoid over-fetching

## Security Rules
- Never store plain text passwords — use ASP.NET Core Identity or BCrypt
- Never log sensitive data (passwords, tokens, PII)
- Always use [Authorize] on protected endpoints
- Use IOptions<T> for configuration — never read IConfiguration directly in services
- Connection strings always from environment variables or User Secrets — never hardcoded

## Error Handling
- Use global exception middleware — never try/catch in every controller
- Use Result<T> pattern or custom ApiResponse<T> wrapper
- Return ProblemDetails (RFC 7807) for all errors