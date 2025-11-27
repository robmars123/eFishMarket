Solution Architecture - Modular Monolithic with Clean Architecture

## Folder Structure

├── Modules/
│   ├── Products/                      # Product metadata, categories, variants
│   │   ├── Application/
│   │   ├── Domain/
│   │   ├── Infrastructure/
│   │   └── Web/

│   ├── Users/                          # User profiles, roles, preferences
│   │   ├── Application/
│   │   ├── Domain/
│   │   ├── Infrastructure/
│   │   └── Web/
│
│   ├── Identity/                       # Authentication, authorization, token issuance
│   │   ├── Application/               # Login, registration, password reset, token commands
│   │   ├── Domain/                    # IdentityUser, Role, Claims, Policies
│   │   ├── Infrastructure/            # ASP.NET Identity, EF mappings, token services
│   │   └── Web/                       # Auth endpoints (login, register, refresh, etc.)
│
│   ├── Inventory/                     # Stock levels, availability, warehouses
│   │   ├── Application/
│   │   ├── Domain/
│   │   ├── Infrastructure/
│   │   └── Web/
│
│   ├── Orders/                        # Cart, checkout, order lifecycle
│   │   ├── Application/
│   │   ├── Domain/
│   │   ├── Infrastructure/
│   │   └── Web/
│
│   ├── Payments/                      # Payment methods, transactions, refunds
│   │   ├── Application/
│   │   ├── Domain/
│   │   ├── Infrastructure/
│   │   └── Web/
│
│   ├── Fulfillment/                   # Shipping, delivery, pickup scheduling
│   │   ├── Application/
│   │   ├── Domain/
│   │   ├── Infrastructure/
│   │   └── Web/
│
│   ├── Notifications/                # Email, SMS, push alerts
│   │   ├── Application/
│   │   ├── Domain/
│   │   ├── Infrastructure/
│   │   └── Web/
│
│   ├── Reviews/                      # Ratings, feedback, moderation
│   │   ├── Application/
│   │   ├── Domain/
│   │   ├── Infrastructure/
│   │   └── Web/
│
│   └── Carts/                         # Persistent cart, item management, promotions
│       ├── Application/
│       ├── Domain/
│       ├── Infrastructure/
│       └── Web/

├── ApiGateway/                        # Optional: API gateway for routing and composition
│   └── Web/

├── Infrastructure/                   # Global infrastructure (cross-cutting concerns)
│   ├── Persistence/                  # Shared EF DbContexts, migrations
│   ├── Messaging/                    # RabbitMQ, Kafka, etc.
│   ├── Monitoring/                   # Serilog, OpenTelemetry, health checks
│   ├── Authentication/              # JWT setup, policies, middleware
│   └── Security/                     # CORS, rate limiting, headers

├── WebApi/                            # Entry point (Program.cs, DI, middleware)
│   ├── Program.cs
│   ├── Startup.cs (if used)
│   └── Configuration/                # Modular DI, app settings, policies

├── Common/                      # Optional: common value objects (Money, Email, Address)
│   ├── Domain/
│   └── Application/

├── Tests/
│   ├── Unit/
│   │   ├── Identity/
│   │   ├── Orders/
│   │   └── Products/
│   ├── Integration/
│   └── Architecture/

├── AspireAppHost/                     # Optional: .NET Aspire orchestration
├── docker-compose.yml                 # Local orchestration (Postgres, Redis, RabbitMQ, etc.)
└── README.md


Migrations:

--Products Module
1. dotnet ef migrations add AddProducts --project "D:\Projects\Modular Monolith - Azure\eFishMarket\src\api\EFM.BoundedContext\Products\EFM.Products.Infrastructure" --startup-project "D:\Projects\Modular Monolith - Azure\eFishMarket\src\api\EFM.Api" --context ProductDbContext
2. dotnet ef database update --project "D:\Projects\Modular Monolith - Azure\eFishMarket\src\api\EFM.BoundedContext\Products\EFM.Products.Infrastructure" --startup-project "D:\Projects\Modular Monolith - Azure\eFishMarket\src\api\EFM.Api" --context ProductDbContext

--Inventory Module
1. dotnet ef migrations add AddInventory --project "D:\Projects\Modular Monolith - Azure\eFishMarket\src\api\EFM.BoundedContext\Inventory\EFM.Inventory.Infrastructure" --startup-project "D:\Projects\Modular Monolith - Azure\eFishMarket\src\api\EFM.Api" --context InventoryDbContext
2. dotnet ef database update --project "D:\Projects\Modular Monolith - Azure\eFishMarket\src\api\EFM.BoundedContext\Inventory\EFM.Inventory.Infrastructure" --startup-project "D:\Projects\Modular Monolith - Azure\eFishMarket\src\api\EFM.Api" --context InventoryDbContext

--Client Side Build - ReactClient
1. npm run build
