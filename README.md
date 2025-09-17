# .NET 8 N-Layer Architecture Template

A clean, modular **.NET 8 Web API** template implementing an **N-Layer Architecture**.  
Use this as a starting point for APIs with clear separation of concerns.

---

## 🗂 Project Structure

src/
├── TelegramBotApi/ # ASP.NET Core Web API (Presentation Layer)
├── ApiFramework/ # Business logic, DTOs, Use Cases
├── ServicesLayer/ # Services, Repeated Scenarios
├── Entities/ # Entities, Value Objects, Domain Events, Interfaces
├── AccessLayer/ # EF Core, Repositories, External Services
└── Common/ (optional) # Cross-cutting concerns


---

## 🛠 Technologies

- .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core 8  
- SQL Server (default)  
- Dependency Injection  

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server or another supported database

### Clone & Restore
```bash
git clone https://github.com/mehrdadsrobot/.NetCore8-Nlayer-Api.git
cd .NetCore8-Nlayer-Api
dotnet restore
```

### Infrastructure and Migrations
```
cd src/Infrastructure
dotnet ef database update
```


### 🤝 Contributing

- Pull requests and commit changes are welcome!

