# Clean Architecture Implementation - Portal.Api

## Overview

This document outlines the clean architecture and SOLID principles applied to the Portal.Api layer.

## Architecture Layers

### 1. Controllers (Presentation Layer)

**Responsibility**: Route HTTP requests to handlers. Nothing more.

**Principles Applied**:

- ✅ **Single Responsibility**: Controllers only route requests to MediatR
- ✅ **Dependency Inversion**: Depend on `IMediator` abstraction, not concrete implementations
- ✅ **No Business Logic**: All validation, processing, and decisions happen in handlers
- ✅ **No Exception Handling**: Delegated to global middleware
- ✅ **Strongly Typed**: Use `ActionResult<T>` with proper DTOs
- ✅ **DRY Principle**: No repeated code, no try-catch blocks

**Example**:

```csharp
[HttpPost]
public async Task<ActionResult<JobPostDto>> CreateJobPost([FromBody] CreateJobPostAction action)
{
    var request = new CreateJobPostRequest(Guid.NewGuid(), action);
    var result = await _mediator.Send(request);
    return CreatedAtAction(nameof(GetJobPost), new { id = result.JobPost.Id }, result.JobPost);
}
```

### 2. Handlers (Business Layer)

**Location**: `Portal.Api/Handlers/`

**Responsibility**:

- Execute business logic
- Validate business rules
- Orchestrate database operations
- Map between entities and DTOs

**Principles Applied**:

- ✅ **Single Responsibility**: Each handler handles one command/query
- ✅ **CQRS Pattern**: Separate handlers for Commands (write) and Queries (read)
- ✅ **Transaction Management**: Use database transactions for multi-entity operations
- ✅ **Atomicity**: All-or-nothing operations with rollback on failure
- ✅ **Proper Logging**: Log business events and errors

**Example**:

```csharp
public async Task<RegisterStudentResult> Handle(RegisterStudentRequest request, CancellationToken cancellationToken)
{
    using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    try
    {
        // Business validation
        var emailExists = await _context.UserProfiles.AnyAsync(u => u.Email == email);
        if (emailExists) return new RegisterStudentResult(...);

        // Business logic
        var userProfile = new UserProfile { ... };
        _context.UserProfiles.Add(userProfile);

        await _context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return new RegisterStudentResult(...);
    }
    catch (Exception ex)
    {
        await transaction.RollbackAsync(cancellationToken);
        _logger.LogError(ex, "Error registering student");
        throw;
    }
}
```

### 3. Middleware (Cross-Cutting Concerns)

**Location**: `Portal.Api/Middleware/`

**GlobalExceptionMiddleware**:

- ✅ Centralized exception handling
- ✅ Consistent error responses
- ✅ Maps exception types to HTTP status codes
- ✅ Prevents exception details leaking to clients
- ✅ Comprehensive logging

**Exception Mapping**:

```csharp
KeyNotFoundException => 404 Not Found
InvalidOperationException => 400 Bad Request
UnauthorizedAccessException => 401 Unauthorized
ArgumentException => 400 Bad Request
Exception => 500 Internal Server Error
```

### 4. Filters (Request Validation)

**Location**: `Portal.Api/Filters/`

**ValidateModelStateFilter**:

- ✅ Automatic model validation before controller action
- ✅ Returns 400 Bad Request if validation fails
- ✅ Removes validation code from controllers

## SOLID Principles Applied

### Single Responsibility Principle (SRP)

- ✅ Controllers: Only route requests
- ✅ Handlers: Only execute one business operation
- ✅ Middleware: Only handle exceptions
- ✅ Filters: Only validate model state

### Open/Closed Principle (OCP)

- ✅ New handlers can be added without modifying existing code
- ✅ MediatR auto-discovers handlers via reflection
- ✅ Exception handling extended by adding cases to middleware

### Liskov Substitution Principle (LSP)

- ✅ All handlers implement `IRequestHandler<TRequest, TResult>`
- ✅ All controllers inherit from `ControllerBase`
- ✅ Substitutable without breaking behavior

### Interface Segregation Principle (ISP)

- ✅ Controllers depend only on `IMediator`
- ✅ Handlers depend only on `ApplicationDbContext` and `ILogger`
- ✅ No fat interfaces with unused methods

### Dependency Inversion Principle (DIP)

- ✅ Controllers depend on `IMediator` abstraction
- ✅ Handlers depend on `DbContext` (EF Core abstraction)
- ✅ All dependencies injected via constructor
- ✅ No direct instantiation of dependencies

## Additional Best Practices

### 1. No Anonymous Objects

❌ **Bad**: `return Ok(new { message = "Success" });`  
✅ **Good**: `return Ok(result);` where `result` is a strongly-typed DTO

### 2. Consistent Response Types

✅ Use `ActionResult<T>` for type safety
✅ Use `ProducesResponseType` attributes for OpenAPI documentation

### 3. No Direct Entity Exposure

❌ **Bad**: Returning `UserProfile` entity in API response  
✅ **Good**: Returning `UserProfileDto` from ViewModels layer

### 4. Separation of Concerns

- **Domain**: Entities and business rules
- **ViewModels**: DTOs, Requests, Results, Commands
- **Portal.Api**: Controllers, Handlers, Middleware
- **No Cross-Contamination**: Controllers never reference Domain entities

## Code Quality Metrics

### Before Refactoring:

- Controllers: ~70 lines each
- Duplicated exception handling: 3 try-catch per endpoint
- Anonymous objects in responses
- Business logic in controllers (success checking)
- No centralized error handling

### After Refactoring:

- Controllers: ~15 lines each (78% reduction)
- Zero duplicated exception handling
- Strongly-typed responses
- Business logic isolated in handlers
- Global exception middleware

## Testing Strategy

### Unit Testing

- **Handlers**: Test business logic in isolation with mocked DbContext
- **Controllers**: Test routing and model binding only
- **Middleware**: Test exception mapping and response formatting

### Integration Testing

- **End-to-End**: Test complete request pipeline including middleware
- **Database**: Use in-memory or test database

## Future Improvements

1. **Add FluentValidation Behaviors**: Validate requests before reaching handlers
2. **Add Logging Behavior**: Centralize logging for all requests/responses
3. **Add Caching Behavior**: Cache query results with MediatR pipeline behavior
4. **Add Performance Monitoring**: Track handler execution times
5. **Add Result Pattern**: Replace exceptions with Result<T> for flow control
6. **Add Repository Pattern**: Abstract data access if multiple data sources needed

## Summary

The refactored architecture follows these principles:

✅ **Thin Controllers**: Only routing, no logic  
✅ **Rich Handlers**: All business logic centralized  
✅ **Global Error Handling**: Consistent error responses  
✅ **SOLID Principles**: Every class has one reason to change  
✅ **Clean Code**: No duplication, high cohesion, low coupling  
✅ **Testability**: Easy to mock and test in isolation  
✅ **Maintainability**: Changes localized to single files

This is production-ready, enterprise-grade .NET architecture.
