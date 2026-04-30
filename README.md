# HX.MCPServer

A Model Context Protocol (MCP) server implementation in C# that provides recipe management tools through the DummyJSON API. This server demonstrates how to build MCP tools for external API integration with robust error handling and logging.

## Overview

This MCP server exposes recipe-related functionality to AI assistants and other MCP clients. It provides tools for searching, retrieving, and browsing recipes from the DummyJSON API, along with a simple echo tool for testing connectivity.

## Features

- **Recipe Management Tools**:
  - Get recipe by ID
  - Search recipes by query
  - Browse recipes with pagination, sorting, and field selection
- **Echo Tool**: Simple message echoing for testing
- **Robust Error Handling**: Comprehensive validation and error reporting
- **Structured Logging**: Console logging with proper log levels
- **Type-Safe DTOs**: Well-defined data transfer objects for API responses

## Technology Stack

- **Framework**: .NET 10.0
- **MCP Library**: ModelContextProtocol v1.2.0
- **HTTP Client**: Microsoft.Extensions.Http for API calls
- **Dependency Injection**: Microsoft.Extensions.DependencyInjection
- **Logging**: Microsoft.Extensions.Logging with console output
- **Configuration**: Microsoft.Extensions.Configuration with JSON support

## Project Structure

```
HX.MCPServer/
├── HX.MCPServer/                 # Main executable project
│   ├── Program.cs               # Application entry point and MCP server setup
│   ├── appsettings.json         # Configuration (DummyJSON API URL and Db Connection Strings)
│   └── HX.MCPServer.csproj      # Project file
├── HX.MCPServer.Tool/           # MCP tools implementation
│	├── PolicyTool.cs			 # Policy API tools
│	├── UnderwriterTool.cs       # Underwriter API tools
│   └── DummyJsonTool.cs         # Recipe API tools	
├── HX.MCPServer.Dto/            # Data transfer objects
│   ├── PolicyDto.cs             # Individual policy model
│	├── UnderwriterDto.cs        # Individual underwriter model
│   ├── RecipeDto.cs             # Individual recipe model
│   └── RecipeSearchDto.cs       # Recipe search results model
├── HX.MCPServer.Entity			 # Database model
│	├── Policy.cs			     # Individual policy db entity
│	├── Underwriter.cs           # Individual underwriter db entity
│   └── BaseEntity.cs            # Base entity	
└── .vscode/
    └── mcp.json                 # VS Code MCP client configuration
```

## Available Tools

### 1. Echo Tool

- **Purpose**: Test server connectivity
- **Method**: `Echo(string message)`
- **Returns**: `"hello {message}"`

### 2. Get Recipe By ID

- **Purpose**: Retrieve a specific recipe by its unique identifier
- **Method**: `GetRecipeByIdAsync(int recipeId)`
- **Parameters**:
  - `recipeId`: The unique identifier of the recipe
- **Returns**: JSON serialized recipe data

### 3. Search Recipes

- **Purpose**: Search for recipes using a query string
- **Method**: `SearchRecipeAsync(string query)`
- **Parameters**:
  - `query`: Search terms to find recipes
- **Returns**: JSON serialized search results

### 4. Get Recipes (Browse)

- **Purpose**: Browse recipes with advanced options
- **Method**: `GetRecipesAsync(...)`
- **Parameters**:
  - `limit`: Number of recipes to retrieve (default: 10, use 0 for all)
  - `skip`: Number of recipes to skip for pagination (default: 0)
  - `select`: Comma-separated fields to select (optional)
  - `sortBy`: Field name to sort by (optional)
  - `order`: Sort order 'asc' or 'desc' (default: 'asc')
- **Returns**: JSON serialized recipe list with pagination info

### 5. Get Policies

- **Purpose**: Search for policies in a MS SQL Server Database
- **Method**: `GetPoliciesAsync(...)`
- **Parameters**:
  - `carrierContactEmail`: carrier contact email (optional)
  - `insuredName`: insured name (optional)
  - `producer`: producer (optional)
  - `policyNumber`: policy number (optional)
  - `certificateNumber`: certificate number (optional)
  - `skip`: Number of records to skip for pagination (default: 0)
  - `take`: Number of records to take for pagination (default: 10)

### 6. Get Underwriter

- **Purpose**: Search for underwriters in a MS SQL Server Database
- **Method**: `GetUnderwritersAsync(...)`
- **Parameters**: 
  - `firstName`: first name (optional)
  - `lastName`: last name (optional)
  - `email`: email (optional)
  - `title`: title (optional)
  - `skip`: Number of records to skip for pagination (default: 0)
  - `take`: Number of records to take for pagination (default: 10)

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Visual Studio Code (recommended for MCP integration)

## Installation & Setup

1. **Clone the repository**:

   ```bash
   git clone <repository-url>
   cd HX.MCPServer
   ```

2. **Restore dependencies**:

   ```bash
   dotnet restore
   ```

3. **Build the project**:
   ```bash
   dotnet build
   ```

## Running the Server

### Option 1: Direct Execution

```bash
cd HX.MCPServer
dotnet run
```

### Option 2: VS Code MCP Integration

1. Ensure the `.vscode/mcp.json` configuration is present
2. The server will automatically start when accessed through VS Code's MCP client
3. Configuration includes proper working directory setup for `appsettings.json`

### Option 3: Production Build

```bash
dotnet publish -c Release -o ./publish
cd publish
./HX.MCPServer.exe
```

## Configuration

The server uses `appsettings.json` for configuration:

```json
{
  "DummyJSON": {
    "Url": "https://dummyjson.com"
  }
}
```

## Example Usage

Once connected through an MCP client, you can use the tools:

```
# Echo test
Echo("test") → "hello test"

# Get specific recipe
GetRecipeByIdAsync(1) → Returns Classic Margherita Pizza details

# Search for recipes
SearchRecipeAsync("pizza") → Returns pizza-related recipes

# Browse recipes with pagination
GetRecipesAsync(5, 0) → Returns first 5 recipes

Search for Policies
GetPoliciesAsync("POL-2025-003") → Returns below 
	•	Policy Number: POL-2025-003
	•	Certificate Number: CERT-003-2025
	•	Insured: Metro Manufacturing Inc
	•	Effective Date: 2025-02-01
	•	Expiration Date: 2026-02-01
	•	Issue Date: 2025-01-20
..

# Search for Underwriters
GetUnderwritersAsync("smith") → Returns John Smith

## Development

### Adding New Tools

1. Create methods in `DummyJsonTool.cs` or new tool classes
2. Decorate with `[McpServerTool]` and `[Description]` attributes
3. Mark the class with `[McpServerToolType]`
4. Register in `Program.cs` using `.WithTools<YourToolClass>()`

### Logging

All operations are logged to stderr with appropriate log levels:

- Information: Normal operations
- Warning: Non-critical issues (e.g., no results found)
- Error: Critical errors with validation failures

## License

[Include your license information here]

## Contributing

[Include contribution guidelines here]
