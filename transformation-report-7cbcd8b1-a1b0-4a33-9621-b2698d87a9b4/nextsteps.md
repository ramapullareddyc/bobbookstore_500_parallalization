# Next Steps

## Overview

The transformation appears to be successful with no build errors reported across any of the projects in the solution (Bookstore.Data, Bookstore.Web, and Bookstore.Domain). This indicates that the migration to cross-platform .NET has completed without compilation issues.

## Validation Steps

### 1. Verify Project Configuration

Review each project file to confirm the transformation:

```bash
# Check target frameworks
dotnet list package
```

- Ensure all projects target a modern .NET version (net6.0, net7.0, or net8.0)
- Verify that package references have been updated to compatible versions
- Confirm that any legacy .NET Framework-specific packages have been replaced

### 2. Build Verification

Perform a clean build to ensure reproducibility:

```bash
# Clean all build artifacts
dotnet clean

# Restore dependencies
dotnet restore

# Build in Release configuration
dotnet build --configuration Release
```

### 3. Run Unit Tests

Execute all test projects to validate functionality:

```bash
# Run all tests in the solution
dotnet test

# Run with detailed output
dotnet test --verbosity normal

# Generate code coverage if tests exist
dotnet test --collect:"XPlat Code Coverage"
```

### 4. Runtime Validation

#### For Bookstore.Web (Web Application)

```bash
# Run the web application locally
cd app/Bookstore.Web
dotnet run

# Test on different operating systems if possible
# - Windows
# - Linux (via WSL or native)
# - macOS
```

Verify the following:
- Application starts without runtime errors
- All endpoints respond correctly
- Static files are served properly
- Database connections work (if applicable)
- Authentication/authorization functions correctly

#### For Bookstore.Data (Data Layer)

- Test database connectivity with the target database provider
- Verify Entity Framework Core migrations (if applicable):
  ```bash
  dotnet ef migrations list
  dotnet ef database update
  ```
- Validate that data access operations work correctly

#### For Bookstore.Domain (Domain Layer)

- Ensure business logic executes as expected
- Validate any domain services or repositories
- Test domain model behavior

### 5. Configuration Review

Check application configuration files:

- **appsettings.json**: Verify connection strings and configuration values
- **launchSettings.json**: Confirm launch profiles are appropriate
- **web.config**: Remove if no longer needed (IIS-specific)
- Environment-specific settings (Development, Staging, Production)

### 6. Dependency Analysis

Review third-party dependencies:

```bash
# List all package dependencies
dotnet list package --include-transitive

# Check for deprecated packages
dotnet list package --deprecated

# Check for vulnerable packages
dotnet list package --vulnerable
```

Update any outdated or vulnerable packages:

```bash
dotnet add package <PackageName> --version <LatestVersion>
```

### 7. API Compatibility Testing

If the application exposes APIs:

- Test all API endpoints with tools like Postman or curl
- Verify request/response formats remain unchanged
- Validate error handling and status codes
- Check API documentation is still accurate

### 8. Performance Baseline

Establish performance metrics:

- Measure application startup time
- Test response times for key operations
- Monitor memory usage
- Compare against legacy application metrics if available

### 9. Platform-Specific Testing

Test on target deployment platforms:

- **Windows**: Run on Windows Server or Windows 10/11
- **Linux**: Test on Ubuntu, Debian, or target distribution
- **macOS**: Verify functionality if this is a deployment target

### 10. Deployment Preparation

#### Self-Contained vs Framework-Dependent

Decide on deployment model:

```bash
# Framework-dependent (requires .NET runtime on target)
dotnet publish -c Release

# Self-contained (includes runtime)
dotnet publish -c Release --self-contained true -r <runtime-identifier>
```

Common runtime identifiers:
- `win-x64` (Windows 64-bit)
- `linux-x64` (Linux 64-bit)
- `osx-x64` (macOS 64-bit)

#### Publish the Application

```bash
# Publish for production
dotnet publish -c Release -o ./publish

# Verify published output
ls ./publish
```

### 11. Documentation Updates

Update project documentation:

- README files with new build/run instructions
- Deployment guides reflecting cross-platform capabilities
- System requirements (new .NET runtime version)
- Any breaking changes or migration notes

### 12. Rollback Plan

Prepare a rollback strategy:

- Maintain the legacy codebase in a separate branch
- Document differences between old and new implementations
- Create a rollback procedure document
- Test the rollback process in a non-production environment

## Common Issues to Watch For

Even with no build errors, monitor for these potential runtime issues:

- **Path separators**: Ensure code uses `Path.Combine()` instead of hardcoded `\` or `/`
- **Case sensitivity**: Linux file systems are case-sensitive
- **Line endings**: Verify that line ending differences don't cause issues
- **Windows-specific APIs**: Confirm no P/Invoke or Windows-only code remains
- **Configuration sources**: Environment variables, user secrets, and configuration providers work correctly
- **File permissions**: Ensure appropriate permissions on Linux/macOS

## Final Deployment

Once validation is complete:

1. Deploy to a staging environment first
2. Perform smoke tests in staging
3. Monitor logs and performance metrics
4. Conduct user acceptance testing if applicable
5. Deploy to production with monitoring enabled
6. Keep the rollback plan readily available

## Success Criteria

The migration is complete when:

- All automated tests pass
- Manual testing confirms feature parity
- Performance meets or exceeds baseline metrics
- Application runs successfully on all target platforms
- No runtime errors occur during normal operation