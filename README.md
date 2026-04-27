# 📱 MobileFix — Mobile Repair Shop Management System

A full-featured **ASP.NET Core MVC** web application for managing mobile repair shop operations. Built with a **Master-Details** pattern, it supports customer registration, device tracking, multi-service assignment, image uploads, and role-based access control using ASP.NET Identity.

---

## 🚀 Features

- **Customer Management** — Register customers with device info, problem description, buying date, and device age
- **Master-Details Pattern** — Each customer can be assigned multiple repair services via a `ServiceEntry` junction table
- **Device Image Upload** — Upload and display device photos stored in the `wwwroot/Images` folder
- **Service CRUD** — Full Create, Read, Update, Delete operations for repair services
- **Role Management** — Create roles and assign them to registered users via ASP.NET Identity
- **Authentication & Authorization** — Secure login/registration powered by ASP.NET Core Identity
- **Responsive UI** — Bootstrap-based layout with a modern dashboard homepage

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC (.NET 8) |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Auth | ASP.NET Core Identity |
| Frontend | Razor Views, Bootstrap 5 |
| File Uploads | `IFormFile` + `IWebHostEnvironment` |

---

## 📁 Project Structure

```
├── Controllers/
│   ├── CustomerController.cs       # Master-Details CRUD + image upload
│   ├── ServicesController.cs       # Service CRUD
│   └── RoleController.cs           # Role creation & assignment
│
├── Models/
│   ├── Entity/
│   │   ├── Customer.cs             # Customer entity
│   │   ├── Service.cs              # Service entity
│   │   └── ServiceEntry.cs         # Junction table (Customer ↔ Service)
│   └── ViewModels/
│       └── CustomerVM.cs           # ViewModel with IFormFile for image upload
│
├── Data/
│   ├── ApplicationDbContext.cs     # EF Core DbContext with Identity
│   └── ApplicationUser.cs          # Extended IdentityUser (Name, Phone, Role, Address)
│
└── Views/
    ├── Customer/                   # Index, Create, Edit, Delete views
    ├── Services/                   # Index, Create, Edit, Delete views
    └── Role/                       # Index, AssignRole views
```

---

## 🗄️ Database Schema

```
Customer (1) ──────< ServiceEntry >────── (M) Service
   - CustomerId (PK)       - ServiceEntryId (PK)       - ServiceId (PK)
   - CustomerName          - CustomerId (FK)            - ServiceName
   - Phone                 - ServiceId (FK)
   - EntryDate
   - DeviceName
   - Problem
   - DevicePicture
   - BuyingDate
   - DeviceAge
   - IsRegular
   - Address
```

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/SKahasun/Master-Detail-CRUD-with-ASP.NET-Core
   cd Master-Detail-CRUD-with-ASP.NET-Core
   ```

2. **Configure the connection string** in `appsettings.json`
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MobileFixDb;Trusted_Connection=True;"
   }
   ```

3. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

4. **Create the image folder** (if it doesn't exist)
   ```
   wwwroot/Images/
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. Open your browser at `https://localhost:5001`

---

## 📸 Key Screens

| Screen | Description |
|---|---|
| **Home Dashboard** | Summary stats, quick actions, service highlights |
| **Customer List** | Table of all customers with linked services |
| **Create Customer** | Form with dynamic service selection and image upload |
| **Edit Customer** | Pre-filled form; keeps old image if no new file uploaded |
| **Role Management** | Create roles and assign them to registered users |

---

## 🔐 Role Management

- Navigate to **Role → Create Role** to add new roles (e.g., `Admin`, `Technician`)
- Navigate to **Role → Assign Role** to assign a role to any registered user by email

---

## 📦 NuGet Dependencies

```
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.AspNetCore.Identity.UI
```

---

## 📝 Notes

- Device images are stored in `wwwroot/Images/` with randomly generated filenames
- The `ServiceList` field in `CustomerVM` is validated to require at least one service selection
- `ApplicationUser` extends `IdentityUser` with `Name`, `Phone`, `Role`, and `Address` fields

---
