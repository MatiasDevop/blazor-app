# JWT Authentication & Authorization Implementation

## Overview

JWT Bearer authentication configured with Auth0 integration following .NET security best practices.

## Configuration

### appsettings.json

```json
{
  "Auth0": {
    "Domain": "your-tenant.auth0.com",
    "Audience": "https://api.cpcccampusapp.com"
  }
}
```

### NuGet Packages

- `Microsoft.AspNetCore.Authentication.JwtBearer` - JWT Bearer token validation

## Implementation

### 1. Program.cs - Authentication & Authorization Setup

**Authentication Configuration**:

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://{domain}/";
        options.Audience = audience;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = ClaimTypes.NameIdentifier,
            ValidateIssuer = true,
            ValidIssuer = $"https://{domain}/",
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
```

**Authorization Policies**:

- `RequireStudentRole` - Requires ProfileType=Student claim
- `RequireRecruiterRole` - Requires ProfileType=BusinessAdmin claim
- `RequireCareerCenterRole` - Requires ProfileType=BusinessAdmin claim
- `RequireAdminRole` - Requires role=Admin claim

**Middleware Pipeline** (correct order):

1. GlobalExceptionMiddleware
2. UseAuthentication()
3. UseAuthorization()
4. UseCors()
5. MapControllers()

### 2. AuthorizedControllerBase

Base controller with helper methods for authenticated endpoints:

```csharp
protected Guid GetUserId()
protected string GetUserEmail()
protected bool IsInRole(string role)
```

Automatically requires authentication via `[Authorize]` attribute.

### 3. Controller Authorization Matrix

| Endpoint                               | Authorization      | Policy               |
| -------------------------------------- | ------------------ | -------------------- |
| POST /api/userprofile/student          | **Public**         | [AllowAnonymous]     |
| POST /api/userprofile/company          | **Public**         | [AllowAnonymous]     |
| POST /api/userprofile/careercenter     | **Public**         | [AllowAnonymous]     |
| GET /api/userprofile/{id}              | **Authenticated**  | [Authorize]          |
| GET /api/userprofile/email/{email}     | **Authenticated**  | [Authorize]          |
| GET /api/jobposts/{id}                 | **Public**         | [AllowAnonymous]     |
| POST /api/jobposts                     | **Recruiter Only** | RequireRecruiterRole |
| GET /api/jobapplications/user/{userId} | **Authenticated**  | [Authorize]          |
| POST /api/jobapplications              | **Authenticated**  | [Authorize]          |

### 4. Security Best Practices Applied

✅ **Token Validation**: Validates issuer, audience, and lifetime  
✅ **Zero Clock Skew**: No grace period for expired tokens  
✅ **Claims-Based Authorization**: Role-based access control via policies  
✅ **Principle of Least Privilege**: Public endpoints explicitly marked with [AllowAnonymous]  
✅ **Separation of Concerns**: Authentication logic isolated from business logic  
✅ **Defense in Depth**: Multiple authorization layers (authentication + policies)

### 5. Auth0 Integration Flow

#### Student Registration Flow:

1. User registers via `POST /api/userprofile/student` (public endpoint)
2. UserProfile created in database
3. User logs in via Auth0
4. Auth0 returns JWT with user claims
5. Subsequent requests include JWT in Authorization header
6. API validates JWT and extracts user_id/email from claims

#### Authenticated Request Flow:

```
Client Request:
GET /api/userprofile/12345
Authorization: Bearer <JWT_TOKEN>

↓

JWT Middleware validates token:
- Signature verification
- Issuer check (Auth0 domain)
- Audience check (API identifier)
- Expiration check

↓

Claims extracted and mapped to User principal

↓

Authorization middleware checks [Authorize] attribute

↓

Controller receives authenticated request
```

### 6. Common Claims in Auth0 JWT

```json
{
  "sub": "auth0|12345", // User ID
  "email": "user@example.com", // Email
  "ProfileType": "Student", // Custom claim
  "role": "Admin", // Custom claim (for admins)
  "iat": 1650000000, // Issued at
  "exp": 1650086400 // Expiration
}
```

### 7. Custom Claims Configuration

To add custom claims in Auth0, create an Action:

```javascript
exports.onExecutePostLogin = async (event, api) => {
  const namespace = "https://api.cpcccampusapp.com";

  // Get user profile from your database
  const userProfile = await getUserProfile(event.user.email);

  if (userProfile) {
    api.idToken.setCustomClaim(
      `${namespace}/ProfileType`,
      userProfile.profileType,
    );
    api.accessToken.setCustomClaim(
      `${namespace}/ProfileType`,
      userProfile.profileType,
    );
  }
};
```

### 8. Error Responses

**401 Unauthorized** - No token or invalid token:

```json
{
  "statusCode": 401,
  "message": "Unauthorized access",
  "timestamp": "2026-04-11T10:30:00Z"
}
```

**403 Forbidden** - Valid token but insufficient permissions:

```json
{
  "type": "https://tools.ietf.org/html/rfc7235#section-3.1",
  "title": "Forbidden",
  "status": 403
}
```

### 9. Testing with JWT

**Using curl**:

```bash
# Get JWT from Auth0
TOKEN=$(curl -X POST https://your-tenant.auth0.com/oauth/token \
  -H 'content-type: application/json' \
  -d '{"client_id":"...","client_secret":"...","audience":"...","grant_type":"client_credentials"}' \
  | jq -r .access_token)

# Make authenticated request
curl -X GET https://localhost:5001/api/userprofile/12345 \
  -H "Authorization: Bearer $TOKEN"
```

**Using Postman**:

1. Set Authorization type to "Bearer Token"
2. Paste JWT in token field
3. Send request

### 10. Production Considerations

✅ **HTTPS Only**: Enforce HTTPS in production  
✅ **Secure Secrets**: Store Auth0 credentials in Azure Key Vault / AWS Secrets Manager  
✅ **Token Refresh**: Implement refresh token flow for long-lived sessions  
✅ **Rate Limiting**: Add rate limiting middleware to prevent abuse  
✅ **Audit Logging**: Log all authentication attempts and authorization failures  
✅ **CORS Configuration**: Restrict origins to known frontends only

### 11. Future Enhancements

- [ ] Add token caching for performance
- [ ] Implement refresh token rotation
- [ ] Add multi-factor authentication (MFA) support
- [ ] Implement API key authentication for service-to-service calls
- [ ] Add request signing for sensitive operations
- [ ] Implement IP whitelisting for admin endpoints

## Summary

The API now implements enterprise-grade authentication and authorization:

✅ **JWT Bearer Authentication** with Auth0  
✅ **Claims-Based Authorization** with custom policies  
✅ **Public Registration Endpoints** for user onboarding  
✅ **Protected Endpoints** requiring valid JWTs  
✅ **Role-Based Access Control** for different user types  
✅ **Helper Methods** in base controller for claim extraction  
✅ **Proper Middleware Ordering** for security pipeline

This implementation follows Microsoft's security guidelines and Auth0 best practices.
