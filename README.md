# PROG7311_FarmersHub

# FarmersHub – Agri-Energy Connect Prototype

This ASP.NET Core MVC web application serves as a prototype for the FarmersHub platform. It enables two user roles: **Farmers** and **Employees**, each with specific functionality.

## Features

### Authentication & Roles
- **Farmers** can:
  - Add products
  - View their own products

- **Employees** can:
  - Add new farmers
  - View all farmers
  - Filter/view products by category and date

## Demo Login Details

| Role     | Email                  | Password   |
|----------|------------------------|------------|
| Farmer   | `farmer1@agri.com`     | `Agri123!` |
| Employee | `employee1@agri.com`   | `Agri123!` |

## How it Works

This web application simulates the Agri-Energy Connect platform by managing two types of users: Farmers and Employees.

Farmers log in to add agricultural products and view their own submissions.

Employees can register new farmers and view/filter products across all farms.

The system uses ASP.NET Identity for role-based access control, with separate views and controller actions depending on user roles. All data is stored in a local SQL Server database and seeded with sample accounts and products on first launch.




