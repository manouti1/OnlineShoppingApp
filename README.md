# 🛒 Online Shopping App

An ASP.NET Core MVC web application for managing an online shopping cart, applying discounts based on purchase amount, and showing purchase summaries.

---

## 📋 Features

- List all products (Name, Description, Price, Discount, Final Price)
- Add products to the cart
- Remove products from the cart with **confirmation**
- Automatic discount applied if the total exceeds a cap (e.g., $5000)
- View purchase summary including discounts
- Responsive UI with Bootstrap 5

---

## 🚀 How to Run

1. **Clone the repository**

2. **Configure the database**
    - Update `appsettings.json` with your database connection string.

3. **Run database migrations**
    ```bash
    dotnet ef database update
    ```

4. **Run the project**
    ```bash
    dotnet run
    ```

5. **Open in Browser**
    Navigate to: [https://localhost:7068](https://localhost:7068)

---

## 📦 Tech Stack

- **Backend:** ASP.NET Core MVC (.NET 8 or higher)
- **Frontend:** Bootstrap 5
- **Database:** SQL Server (or your configured provider)

---

## 🎯 Logic for Discount

- If the **cart total amount** is **above $5000**, a discount will apply automatically per product.
- If the total is **below $5000**, no discounts are applied.
- Discount and final price are calculated dynamically and shown in both product listing and purchase summary.

---
