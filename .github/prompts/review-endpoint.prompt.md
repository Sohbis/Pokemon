---
mode: chat
---
Review this ASP.NET Core code for:
- Business logic leaking into Controller
- Direct DbContext usage outside Infrastructure layer
- Missing async/await
- Entities exposed directly (should use DTOs)
- Missing [Authorize] attribute
- Unbounded list queries (missing pagination)
- Hardcoded strings or connection strings
- Missing error handling / wrong HTTP status codes
- SOLID violations