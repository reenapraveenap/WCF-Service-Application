# 🚀 CoreWCF SOAP Service with ASP.NET Core MVC & WSDL

## 📌 Project Overview

This project demonstrates the implementation of a complete **SOAP-based Web Service** using **CoreWCF with ASP.NET Core /.NET 8** along with proper **WSDL exposure**, **SOAP endpoint configuration**, and **MVC integration**.

This hands-on implementation helped strengthen my practical understanding of enterprise-level service communication and modern SOAP service development in .NET.

---

# 🛠️ Technologies Used

* ASP.NET Core /.NET 8
* CoreWCF
* SOAP Web Services
* WSDL
* MVC
* C#
* Dependency Injection
* HTTPS Security

---

# 📂 Project Flow

```text
Model
   ↓
Service Contract
   ↓
Operation Contract
   ↓
Service Implementation
   ↓
Dependency Injection
   ↓
SOAP Endpoint (.svc)
   ↓
WSDL Exposure
   ↓
Postman Testing
   ↓
GitHub Deployment
```

---

# ✅ Step-by-Step Implementation

## 1️⃣ Create ASP.NET Core MVC Project

```bash
ASP.NET Core Web App (MVC)
```

### ✔ Why?

CoreWCF works inside ASP.NET Core applications.

---

# 2️⃣ Install Required Packages

```powershell
Install-Package CoreWCF.Http
Install-Package CoreWCF.Primitives
```

### ✔ Purpose

* `CoreWCF.Http` → SOAP communication
* `CoreWCF.Primitives` → WCF base contracts

---

# 3️⃣ Create Model

## Example:

```csharp
TruckModel
```

### Properties:

```text
TruckId
TruckName
DriverName
ServiceStatus
```

### ✔ Purpose

* SOAP response object
* Data transfer model

---

# 4️⃣ Create Service Contract Interface

## Example:

```csharp
ITruckService
```

### Add Attributes:

```csharp
[ServiceContract]
```

### Add Methods:

```csharp
[OperationContract]
TruckModel GetTruckById(int id);
```

---

# 📖 Important Concepts

| Attribute         | Purpose              |
| ----------------- | -------------------- |
| ServiceContract   | Defines SOAP Service |
| OperationContract | Defines SOAP Method  |

---

# 5️⃣ Create Service Implementation

## Example:

```csharp
TruckService : ITruckService
```

### ✔ Purpose

Contains actual business logic implementation.

---

# 6️⃣ Register CoreWCF Services

## Add in `Program.cs`

```csharp
builder.Services.AddServiceModelServices();

builder.Services.AddServiceModelMetadata();
```

### ✔ Purpose

* SOAP Support
* WSDL Support

---

# 7️⃣ Register Dependency Injection

```csharp
builder.Services.AddSingleton<TruckService>();

builder.Services.AddSingleton<ITruckService>(provider =>
    provider.GetRequiredService<TruckService>());
```

---

# 📖 DI Usage

| Registration  | Used By        |
| ------------- | -------------- |
| TruckService  | CoreWCF        |
| ITruckService | MVC Controller |

---

# 8️⃣ Configure SOAP Endpoint

## Inside:

```csharp
app.UseServiceModel(...)
```

### Add:

```csharp
serviceBuilder.AddService<TruckService>();

serviceBuilder.AddServiceEndpoint
<TruckService, ITruckService>(
    new BasicHttpBinding(BasicHttpSecurityMode.Transport),
    "/TruckService.svc");
```

### ✔ Purpose

* Creates SOAP endpoint
* Exposes `.svc` URL

---

# 9️⃣ Enable WSDL

```csharp
var serviceMetadataBehavior =
    app.Services.GetRequiredService<ServiceMetadataBehavior>();

serviceMetadataBehavior.HttpsGetEnabled = true;
```

### ✔ Purpose

Exposes WSDL XML metadata.

---

# 🔟 Add MVC Route

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Truck}/{action=Index}/{id?}");
```

### ✔ Purpose

Enables MVC page routing.

---

# 1️⃣1️⃣ Run Application

```powershell
dotnet clean
dotnet build
dotnet run
```

---

# 🌐 Test URLs

## MVC

```text
https://localhost:7057/
```

## SOAP Endpoint

```text
https://localhost:7057/TruckService.svc
```

## WSDL

```text
https://localhost:7057/TruckService.svc?wsdl
```

---

# 1️⃣2️⃣ Test in Postman

## Header

```text
Content-Type : text/xml
```

### ✔ Send SOAP XML Request

### ✔ Receive SOAP XML Response

---

# 1️⃣3️⃣ Push Project to GitHub

```bash
git init

git add .

git commit -m "Implemented CoreWCF SOAP Service with WSDL"

git branch -M main

git remote add origin YOUR_GITHUB_URL

git push -u origin main
```

---

# 🎯 Key Learnings

✅ SOAP Architecture
✅ WSDL Metadata Publishing
✅ CoreWCF Configuration
✅ HTTPS SOAP Binding
✅ Dependency Injection
✅ Enterprise Service Communication
✅ Modern WCF Migration Concepts
✅ Practical Backend Development

---

# 📌 GitHub Repository

🔗 Add Your GitHub Repository Link Here

---

# 💡 Recruiter Highlights

✔ Enterprise-Level Backend Development
✔ SOAP & WSDL Hands-On Experience
✔ Modern .NET 8 Development
✔ CoreWCF Practical Implementation
✔ Real-Time Service Communication Understanding
✔ Strong Backend Fundamentals

---

# 👩‍💻 Author

**Reena Praveena Pampana**
Associate Software Engineer | .NET Full Stack Developer

---
