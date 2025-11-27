# Next Steps

## Validation and Testing

Congratulations on successfully transforming your Bookstore solution to cross-platform .NET. Since no build errors were detected across any of the projects (Bookstore.Data, Bookstore.Web, and Bookstore.Domain), you can proceed with the following validation and testing steps.

### 1. Verify Build Configuration

```bash
# Clean and rebuild the entire solution
dotnet clean
dotnet build --configuration Release

# Verify all projects build successfully
dotnet build Bookstore.Domain/Bookstore.Domain.csproj
dotnet build Bookstore.Data/Bookstore.Data.csproj
dotnet build Bookstore.Web/Bookstore.Web.csproj
```

### 2. Update and Verify Dependencies

Check that all NuGet packages are compatible with your target framework:

```bash
# List outdated packages
dotnet list package --outdated

# Update packages if necessary
dotnet restore
```

Review your `.csproj` files to ensure the `<TargetFramework>` is set appropriately (e.g., `net6.0`, `net7.0`, or `net8.0`).

### 3. Run Unit Tests

If your solution includes unit tests:

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"

# Generate code coverage report
dotnet test --collect:"XPlat Code Coverage"
```

If no test projects exist, consider creating them to validate business logic in Bookstore.Domain and data access in Bookstore.Data.

### 4. Validate Data Access Layer

For the Bookstore.Data project:

- Verify database connection strings in configuration files (appsettings.json)
- Test database migrations if using Entity Framework Core:
  ```bash
  dotnet ef migrations list --project Bookstore.Data
  dotnet ef database update --project Bookstore.Data
  ```
- Confirm that data access patterns (repositories, DbContext) function correctly

### 5. Test the Web Application Locally

For the Bookstore.Web project:

```bash
# Run the web application
dotnet run --project Bookstore.Web/Bookstore.Web.csproj

# Or specify the environment
dotnet run --project Bookstore.Web/Bookstore.Web.csproj --environment Development
```

Perform the following checks:
- Application starts without runtime errors
- All routes and endpoints respond correctly
- Static files (CSS, JavaScript, images) load properly
- Authentication and authorization work as expected
- Forms and data submission function correctly
- API endpoints return expected responses

### 6. Cross-Platform Validation

Test the application on different operating systems if cross-platform compatibility is required:

- **Windows**: Verify on Windows 10/11
- **Linux**: Test on Ubuntu or your target Linux distribution
- **macOS**: Validate on macOS if applicable

Check for platform-specific issues:
- File path separators (use `Path.Combine()`)
- Case-sensitive file systems on Linux/macOS
- Line ending differences

### 7. Configuration Review

Examine configuration files for legacy settings:

- Remove or update obsolete configuration sections
- Verify connection strings use current format
- Check that environment-specific settings are properly configured
- Ensure secrets are not hardcoded (use User Secrets or environment variables)

### 8. Performance Testing

Conduct basic performance validation:

```bash
# Publish the application in Release mode
dotnet publish Bookstore.Web/Bookstore.Web.csproj -c Release -o ./publish

# Run the published application
dotnet ./publish/Bookstore.Web.dll
```

Monitor:
- Application startup time
- Memory usage
- Response times for key operations

### 9. Review Warnings

Even without errors, check for warnings:

```bash
dotnet build --configuration Release /warnaserror
```

Address any warnings related to:
- Deprecated APIs
- Nullable reference types
- Unused variables or methods

### 10. Documentation Updates

Update project documentation:

- Modify README.md with new build and run instructions
- Document the target framework version
- Update deployment procedures
- Note any breaking changes from the legacy version

## Deployment Preparation

### Pre-Deployment Checklist

- [ ] All tests pass successfully
- [ ] Application runs without errors locally
- [ ] Configuration files are environment-appropriate
- [ ] Database migrations are tested
- [ ] Static files and assets are included in publish output
- [ ] Logging is configured correctly
- [ ] Error handling is functional

### Publish the Application

```bash
# Create a production-ready build
dotnet publish Bookstore.Web/Bookstore.Web.csproj \
  -c Release \
  -o ./publish \
  --self-contained false

# For self-contained deployment (includes runtime)
dotnet publish Bookstore.Web/Bookstore.Web.csproj \
  -c Release \
  -o ./publish \
  --self-contained true \
  -r linux-x64  # or win-x64, osx-x64
```

### Deployment Options

Choose the appropriate hosting environment:

1. **IIS (Windows Server)**
   - Install ASP.NET Core Hosting Bundle
   - Configure application pool with "No Managed Code"
   - Deploy published files to wwwroot

2. **Linux Server (systemd)**
   - Copy published files to server
   - Create systemd service file
   - Configure reverse proxy (nginx/Apache)

3. **Azure App Service**
   - Use Azure CLI or portal deployment
   - Configure application settings in portal

4. **Self-Hosted (Kestrel)**
   - Run directly using `dotnet Bookstore.Web.dll`
   - Configure firewall rules
   - Set up process manager for production

### Post-Deployment Validation

After deployment:

1. Verify the application is accessible at the production URL
2. Test critical user workflows
3. Monitor application logs for errors
4. Verify database connectivity in production environment
5. Test performance under expected load
6. Confirm all integrated services function correctly