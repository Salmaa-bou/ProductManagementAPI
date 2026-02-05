# Product Management API
## Features

-  **Full CRUD operations** with proper HTTP status codes
-  **Clean Architecture** with strict layer separation
-  **CQRS pattern** using MediatR for command/query separation
-  **Repository pattern** for data access abstraction
-  **Entity Framework Core 8.0** with SQL Server
-  **Swagger/OpenAPI** documentation
-  **CORS enabled** for Angular frontend integration
  
---

## 🎯 Architectural Decisions & Rationale

### 1. **Clean Architecture (Onion Architecture)**

**Decision:** Separated concerns into Domain → Application → Infrastructure → Presentation layers.

**Why:**
- ✅ **Testability:** Domain layer has zero dependencies → easy unit testing
- ✅ **Maintainability:** Changes in infrastructure (EF Core, database) don't affect business logic
- ✅ **Flexibility:** Can swap database (SQL Server → PostgreSQL) without touching domain
- ✅ **Team Scalability:** Different teams can work on different layers independently

**Trade-off:** Slightly more complex project structure, but pays off in maintainability.

---

### 2. **CQRS Pattern with MediatR**

**Decision:** Separated Commands (writes) from Queries (reads) using MediatR.

**Why:**
- ✅ **Clear Intent:** `CreateProductCommand` vs `GetProductByIdQuery` – immediately obvious
- ✅ **Optimization:** Queries can bypass repositories for performance (direct SQL projections)
- ✅ **Scalability:** Can scale read/write operations independently in distributed systems
- ✅ **Cross-cutting Concerns:** MediatR pipelines for validation, logging, authorization

**Implementation:**

// Commands (Write) → Use repositories for domain entity operations
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _repository; // Interface from Application layer
    // Handler orchestrates, repository persists
}

// Queries (Read) → Direct DbContext projection (no repository overhead)
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly ApplicationDbContext _context; // Direct access for performance
    // Returns DTO directly, no domain entity loading
}
'''

-----

✅ Commands need domain entities: Business logic requires full entity with methods
✅ Queries need performance: Direct projection avoids unnecessary entity materialization
✅ Single Responsibility: Handlers orchestrate, repositories persist

4. MediatR Pipeline Behaviors
Decision: Use decorator pattern for cross-cutting concerns (validation, logging, etc.).
Why:
✅ Separation of Concerns: Handlers focus on business logic, not infrastructure
✅ Consistency: All commands/queries automatically get validation/logging
✅ Testability: Behaviors can be tested independently
✅ Flexibility: Easy to add/remove behaviors without touching handlers
7. Design-Time DbContext Factory
Decision: Created ApplicationDbContextFactory for EF Core migrations.
Why:
✅ Migration Independence: Migrations don't require full DI container
✅ Avoids Service Resolution Errors: No need to resolve IProductRepository during migrations
✅ Standard EF Core Pattern: Officially recommended approach

10. Thin Controllers Pattern
Decision: Controllers contain only MediatR calls (1 line per action).
Why:
✅ Separation of Concerns: Controllers handle HTTP, handlers handle business logic
✅ Testability: Handlers can be tested without HTTP context
✅ Consistency: All actions follow same pattern
✅ MediatR Benefits: Automatic pipeline behaviors (validation, logging)

