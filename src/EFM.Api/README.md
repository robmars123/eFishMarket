Solution Architecture - Modular Monolithic with Clean Architecture
	src/
	├── BuildingBlocks/                  # Shared kernel and cross-cutting concerns
	│   ├── Application/                 # Base interfaces, Result pattern, pagination
	│   ├── Domain/                      # Base entities, value objects, domain events
	│   ├── Infrastructure/             # Common infra (e.g., Outbox, Email, Logging)
	│   └── Web/                         # Shared web components (e.g., filters, middleware)

	├── Modules/                         # Feature modules (each is isolated)
	│   ├── Users/
	│   │   ├── Application/            # CQRS handlers, DTOs, validators
	│   │   ├── Domain/                 # Entities, aggregates, value objects
	│   │   ├── Infrastructure/         # EF Core mappings, repositories
	│   │   └── Web/                    # API endpoints (minimal APIs or controllers)
	│
	│   ├── Events/
	│   │   ├── Application/
	│   │   ├── Domain/
	│   │   ├── Infrastructure/
	│   │   └── Web/
	│
	│   ├── Followers/
	│   │   ├── Application/
	│   │   ├── Domain/
	│   │   ├── Infrastructure/
	│   │   └── Web/
	│
	│   └── Notifications/
	│       ├── Application/
	│       ├── Domain/
	│       ├── Infrastructure/
	│       └── Web/

	├── ApiGateway/                      # Optional: API gateway for routing and composition
	│   └── Web/

	├── Infrastructure/                 # Global infrastructure (e.g., messaging, persistence)
	│   ├── Persistence/
	│   ├── Messaging/
	│   └── Monitoring/

	├── WebApi/                          # Entry point (Program.cs, DI, middleware)
	│   ├── Program.cs
	│   ├── Startup.cs (if used)
	│   └── Configuration/

	├── Tests/
	│   ├── Unit/
	│   ├── Integration/
	│   └── Architecture/

	├── docker-compose.yml              # Local orchestration (Postgres, RabbitMQ, etc.)
	├── AspireAppHost/                  # Optional: .NET Aspire orchestration
	└── README.md