
# FipeBrasil

FipeBrasil is a web application that integrates a **frontend** built with Vue.js and a **Web API** in .NET. It provides features for managing vehicle brands and models and querying data from the [FIPE Table](https://parallelum.com.br/fipe/api/v1).

---

## 🚀 Overview

This project aims to enable the management and querying of vehicle brands and models. It is divided into three main components:

1. **Frontend**: A user interface for listing and managing vehicle brands.
2. **Backend**: A Web API for storing and retrieving brand data from the database.
3. **Service Worker**: A service that consumes the [FIPE Table](https://parallelum.com.br/fipe/api/v1) API for additional information on vehicles.

---

## 🛠️ Technologies Used

- **Frontend**: [Vue.js](https://vuejs.org/) with [Vuetify](https://vuetifyjs.com/) for UI design.
- **Backend**: 
  - [.NET Core](https://dotnet.microsoft.com/)
  - [MediatR](https://github.com/jbogard/MediatR) for CQRS implementation.
  - [FluentValidation](https://fluentvalidation.net/) for command validation.
  - Database: SQL Server (or any database compatible with Entity Framework Core).
- **Service Worker**: Responsible for integrating with the FIPE Table API.

---

## 📁 Project Structure

```plaintext
FipeBrasil/
├── src/
│   ├── frontend/          # Vue.js application
│   ├── backend/           # .NET Web API
│   │   ├── Services/      # Service Worker for FIPE Table integration
│   │   ├── Controllers/   # REST endpoints
│   │   ├── Domain/        # Business logic and entities
│   │   ├── Infrastructure/ # Repositories and database access
│   ├── tests/             # Unit tests with XUnit
├── README.md              # Project documentation
```

---

## 🔧 Setup and Installation

### **Requirements**

- [Node.js](https://nodejs.org/) (v16 or higher)
- [.NET SDK](https://dotnet.microsoft.com/) (v6.0 or higher)
- SQL Server or another database compatible with Entity Framework Core
- Package manager: `npm` or `yarn`.

### **Setup Steps**

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourproject/FipeBrasil.git
   cd FipeBrasil
   ```

2. **Setup the Backend**
   ```bash
   cd src/backend
   dotnet restore
   ```
   - Configure the `appsettings.json` file with your database connection string.
   - Apply migrations:
     ```bash
     dotnet ef database update
     ```
   - Start the server:
     ```bash
     dotnet run
     ```

3. **Setup the Frontend**
   ```bash
   cd src/frontend
   npm install
   npm run serve
   ```

4. **Access the Application**
   - **Frontend**: http://localhost:8080
   - **Backend**: http://localhost:5000

---

## 🌟 Features

### **Frontend**
- List all registered brands.
- Pagination and search functionality.
- Integration with the Web API to create, update, and delete brands.

### **Backend**
- **Available REST Endpoints**:
  - `GET /api/Brand`: Retrieve all registered brands.
  - `POST /api/Brand`: Create a new brand.
  - `PUT /api/Brand/{id}`: Update an existing brand.
  - `DELETE /api/Brand/{id}`: Delete a brand.
- Data persistence using an SQL database.

### **Service Worker**
- Integration with the [FIPE Table API](https://parallelum.com.br/fipe/api/v1) to:
  - Retrieve vehicle brands.
  - Fetch model details and prices.
- Runs as a backend service.

---

## 🧪 Tests

- Unit tests built with **XUnit**.
- Additional frameworks:
  - [Moq](https://github.com/moq/moq4) for mocking dependencies.
  - [FluentAssertions](https://fluentassertions.com/) for expressive assertions.

Run the tests with the following command:

```bash
cd src/tests
dotnet test
```

---

## 🤝 How to Contribute

1. Fork this repository.
2. Create a new branch:
   ```bash
   git checkout -b my-feature
   ```
3. Commit your changes:
   ```bash
   git commit -m "Added a new feature"
   ```
4. Push your branch:
   ```bash
   git push origin my-feature
   ```
5. Open a Pull Request for review.

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

---
