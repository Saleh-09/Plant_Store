# 🌿 Plant Store - ASP.NET MVC E-Commerce Web App

A simple and elegant e-commerce web application for selling plants online. Users can browse plants by category, add them to the cart, and place orders. Admins can manage plant listings through full CRUD operations.

---

## 🔧 Tech Stack

- **Frontend:** ASP.NET MVC (Razor Views, Bootstrap)
- **Backend:** ASP.NET MVC (Controllers & Services)
- **Database:** SQL Server
- **ORM:** Entity Framework Core (Code First)
- **Architecture:** 3-Tier (Presentation, Business, Data Access Layers using Class Libraries)

---

## 📂 Project Structure

PlantStore.Models # Entity models (shared across layers)
├── PlantStore.DataAccess # EF Core DbContext and Repositories
├── PlantStore # ASP.NET MVC Web App (Presentation Layer)

## ✅ Features

### 🛒 User Side
- Browse plants by category
- Search and filter plants
- View product details
- Add to cart and checkout

### 🛠️ Admin Side
- Login to admin dashboard
- Create, Read, Update, Delete (CRUD) operations on plants
- Manage plant categories

## ⚙️ How to Run

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/plant-store.git
   cd plant-store
2. **Set up the Database**
   Update the appsettings.json connection string in PlantStore project.
   Run migrations from PlantStore.DataAccess project:
    ```bash
   Add-Migration Init -StartupProject PlantStore -Project PlantStore.DataAccess
   Update-Database -StartupProject PlantStore -Project PlantStore.DataAccess
3. **Run the Application**

  Set PlantStore as the startup project.
  Hit F5 or Ctrl + F5 to run in browser.
